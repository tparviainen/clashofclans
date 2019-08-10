using ClashOfClans.Models;
using ClashOfClans.Validation;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClashOfClans.Core
{
    /// <summary>
    /// A base class for accessing Clash of Clans API
    /// </summary>
    internal class ClashOfClansBase
    {
        private readonly string _token;
        protected readonly Validator _validator;
        private readonly ClashOfClansOptionsInternal _options;
        private IThrottleRequests _throttleRequests => _options._throttleRequests;

        /// <summary>
        /// Logging method for diagnostics messages
        /// </summary>
        protected void Log(string message) => _options.Logger?.Log(message);

        public ClashOfClansBase(ClashOfClansOptionsInternal options)
        {
            _options = options;
            _token = options.Token;
            _validator = options._validator;
        }

        private async Task<HttpResponseMessage> GetMessageAsync(string requestUri)
        {
            await _throttleRequests.WaitAsync();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.clashofclans.com/v1/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                return await client.GetAsync(requestUri);
            }
        }

        protected async Task<T> RequestAsync<T>(string uri) where T : class
        {
            // Hash character '#' needs to be URL-encoded properly to work in URL
            var data = await GetDataAsync(uri.Replace("#", "%23"));

            return Deserialize<T>(data);
        }

        private async Task<string> GetDataAsync(string requestUri)
        {
            Log($"API: {GetType().Name}, Uri: /{requestUri}");

            var watch = Stopwatch.StartNew();
            var response = await GetMessageAsync(requestUri);
            Log($"{response}, completed in {watch.ElapsedMilliseconds} ms");

            var content = await response.Content.ReadAsStringAsync();
            Log($"Content: {content}");

            if (response.IsSuccessStatusCode)
            {
                return content;
            }

            try
            {
                var error = Deserialize<Error>(content);
                throw new ClashOfClansException(error);
            }
            catch (Exception ex) when (ex.GetType() != typeof(ClashOfClansException))
            {
                // In case of unknown exception, catch the content that caused the issue
                // to the Reason attribute and provide information to caller.
                var error = new Error
                {
                    Message = ex.Message,
                    Reason = content
                };

                throw new ClashOfClansException(error);
            }
        }

        private T Deserialize<T>(string data) where T : class
        {
            if (data != null)
            {
                using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(data)))
                {
                    var serializer = new JsonSerializer
                    {
#if DEBUG
                        MissingMemberHandling = MissingMemberHandling.Error,
#endif
                        DateFormatString = "yyyyMMddTHHmmss.fffK"
                    };

                    using (var stream = new StreamReader(ms))
                    {
                        var reader = new JsonTextReader(stream);
                        return serializer.Deserialize<T>(reader);
                    }
                }
            }

            return null;
        }
    }
}
