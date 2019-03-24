using ClashOfClans.Models;
using Newtonsoft.Json;
using System;
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
    public class ClashOfClansBase
    {
        private readonly string _token;
        private DateTime _allowedCallTime;

        public ClashOfClansBase(string token)
        {
            _token = token;
            _allowedCallTime = DateTime.Now;
        }

        /// <summary>
        /// Delay between API calls to prevent API throttling
        /// </summary>
        /// <param name="minimumDelay">Minimum delay (in milliseconds) between API calls</param>
        private async Task WaitUntilApiCallAllowed(int minimumDelay)
        {
            var now = DateTime.Now;

            if (now < _allowedCallTime)
            {
                var millisecondsDelay = (int)(_allowedCallTime - now).TotalMilliseconds;
                await Task.Delay(millisecondsDelay);
            }

            _allowedCallTime = now.AddMilliseconds(minimumDelay);
        }

        private async Task<HttpResponseMessage> GetMessageAsync(string requestUri)
        {
            await WaitUntilApiCallAllowed(100);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.clashofclans.com/v1/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse($"Bearer {_token}");

                return await client.GetAsync(requestUri);
            }
        }

        protected async Task<T> RequestAsync<T>(string uri) where T : class
        {
            var data = await GetDataAsync(uri);

            return Deserialize<T>(data);
        }

        private async Task<string> GetDataAsync(string requestUri)
        {
            var response = await GetMessageAsync(requestUri);
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return content;
            }

            var error = Deserialize<Error>(content);
            throw new ClashOfClansException(error);
        }

        private T Deserialize<T>(string data) where T : class
        {
            if (data != null)
            {
                using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(data)))
                {
                    var serializer = new JsonSerializer();
#if DEBUG
                    serializer.MissingMemberHandling = MissingMemberHandling.Error;
#endif

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
