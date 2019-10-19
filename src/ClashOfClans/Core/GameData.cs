using ClashOfClans.Core.Net;
using ClashOfClans.Core.Serialization;
using ClashOfClans.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ClashOfClans.Core
{
    /// <summary>
    /// Provides a functionality to access game data.
    /// </summary>
    internal sealed class GameData : IGameData
    {
        private readonly ApiEndpoint _endpoint;
        private readonly MessageSerializer _serializer;
        private readonly ClashOfClansOptionsInternal _options;
        private IThrottleRequests _throttleRequests => _options.ThrottleRequests;

        /// <summary>
        /// Logging method for diagnostics messages
        /// </summary>
        private void Log(Guid correlationId, string message) => _options.Logger?.Log($"{correlationId}: {message}");

        public GameData(ClashOfClansOptionsInternal options)
        {
            _options = options;
            _endpoint = new ApiEndpoint(options.Token);
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
            var correlationId = Guid.NewGuid();
            Log(correlationId, $"Uri: /{requestUri}");

            var watch = Stopwatch.StartNew();
            await _throttleRequests.WaitAsync();
            Log(correlationId, $"Throttling: {watch.ElapsedMilliseconds} ms");

            watch.Restart();
            var response = await _endpoint.GetMessageAsync(requestUri);
            Log(correlationId, $"{response}, completed in {watch.ElapsedMilliseconds} ms");

            var content = await response.Content.ReadAsStringAsync();
            Log(correlationId, $"Content: {content}");

            if (response.IsSuccessStatusCode)
            {
                return content;
            }

            try
            {
                var error = _serializer.Deserialize<ClientError>(content);
                throw new ClashOfClansException(error);
            }
            catch (Exception ex) when (ex.GetType() != typeof(ClashOfClansException))
            {
                // In case of unknown exception, catch the content that caused the issue
                // to the Reason attribute and provide information to caller.
                var error = new ClientError
                {
                    Message = ex.Message,
                    Reason = content
                };

                throw new ClashOfClansException(error);
            }
        }
    }
}
