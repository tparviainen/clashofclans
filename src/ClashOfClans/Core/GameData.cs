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
        private void Log(AutoValidatedRequest request, string message) => _options.Logger?.Log($"{request.CorrelationId}: {message}");

        public GameData(ClashOfClansOptionsInternal options)
        {
            _options = options;
            _endpoint = new ApiEndpoint(options.Token);
            _serializer = new MessageSerializer();
        }

        public async Task<T> RequestAsync<T>(AutoValidatedRequest request) where T : class
        {
            Log(request, $"Uri: /{request.Uri}");

            var data = await GetDataAsync(request);

            return _serializer.Deserialize<T>(data);
        }

        private async Task<string> GetDataAsync(AutoValidatedRequest request)
        {
            var watch = Stopwatch.StartNew();
            await _throttleRequests.WaitAsync();
            Log(request, $"Throttling: {watch.ElapsedMilliseconds} ms");

            watch.Restart();
            var response = await _endpoint.GetMessageAsync(request.Uri);
            Log(request, $"{response}, completed in {watch.ElapsedMilliseconds} ms");

            var content = await response.Content.ReadAsStringAsync();
            Log(request, $"Content: {content}");

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
