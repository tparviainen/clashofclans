using ClashOfClans.Core.Net;
using ClashOfClans.Core.Serialization;
using ClashOfClans.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ClashOfClans.Core
{
    internal class ClashOfClansEndpoint : IApiEndpoint
    {
        private readonly ApiClient _client;
        private readonly MessageSerializer _serializer;
        private readonly ClashOfClansOptionsInternal _options;
        private IThrottleRequests _throttleRequests => _options.ThrottleRequests;

        /// <summary>
        /// Logging method for diagnostics messages
        /// </summary>
        protected void Log(string message) => _options.Logger?.Log(message);

        public ClashOfClansEndpoint(ClashOfClansOptionsInternal options)
        {
            _options = options;
            _client = new ApiClient(options.Token);
            _serializer = new MessageSerializer();
        }

        public async Task<T> RequestAsync<T>(string uri) where T : class
        {
            // Hash character '#' needs to be URL-encoded properly to work in URL
            var data = await GetDataAsync(uri.Replace("#", "%23"));

            return _serializer.Deserialize<T>(data);
        }

        private async Task<string> GetDataAsync(string requestUri)
        {
            Log($"API: {GetType().Name}, Uri: /{requestUri}");

            var watch = Stopwatch.StartNew();
            await _throttleRequests.WaitAsync();
            var response = await _client.GetMessageAsync(requestUri);
            Log($"{response}, completed in {watch.ElapsedMilliseconds} ms");

            var content = await response.Content.ReadAsStringAsync();
            Log($"Content: {content}");

            if (response.IsSuccessStatusCode)
            {
                return content;
            }

            try
            {
                var error = _serializer.Deserialize<Error>(content);
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
    }
}
