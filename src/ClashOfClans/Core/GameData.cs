using ClashOfClans.Core.Net;
using ClashOfClans.Core.Serialization;
using ClashOfClans.Models;
using ClashOfClans.Search;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ClashOfClans.Core
{
    /// <summary>
    /// Provides a functionality to access game data.
    /// </summary>
    internal sealed class GameData : IGameData
    {
        private readonly ApiEndpoint _endpoint;
        private readonly ClashOfClansOptionsInternal _options;
        private IThrottleRequests ThrottleRequests => _options.ThrottleRequests;

#if DEBUG
        private static readonly object _lock = new object();
        private static readonly HashSet<string> _uninitializedProperties = new HashSet<string>();
#endif

        /// <summary>
        /// Logging method for diagnostics messages
        /// </summary>
        private void Log(AutoValidatedRequest request, string message) => _options.Logger?.Log($"{request.CorrelationId}: {message}");

        public GameData(ClashOfClansOptionsInternal options)
        {
            _options = options;
            _endpoint = new ApiEndpoint(options.Tokens);
        }

        public async Task<QueryResult<T>> QueryAsync<T>(AutoValidatedRequest request) where T : class
        {
            var deserializedData = await RequestAsync<QueryResult<T>>(request).ConfigureAwait(false);

            request.Query?.SetCursors(deserializedData.Paging.Cursors);

            return deserializedData;
        }

        public async Task<T> RequestAsync<T>(AutoValidatedRequest request) where T : class
        {
            Log(request, $"Uri: /{request.Uri}");

            var data = await GetDataAsync(request).ConfigureAwait(false);
            var deserializedData = MessageSerializer.Deserialize<T>(data, out var uninitializedProperties);

#if DEBUG
            lock (_lock)
            {
                var count = _uninitializedProperties.Count;
                _uninitializedProperties.UnionWith(uninitializedProperties);

                if (count != _uninitializedProperties.Count)
                {
                    Log(request, $"Aggregate list of null properties: {string.Join($",", _uninitializedProperties.OrderBy(x => x))}");
                }
            }
#endif

            return deserializedData;
        }

        private async Task<string> GetDataAsync(AutoValidatedRequest request)
        {
            var watch = Stopwatch.StartNew();
            await ThrottleRequests.WaitAsync().ConfigureAwait(false);
            Log(request, $"Throttling: {watch.ElapsedMilliseconds} ms");

            watch.Restart();
            var response = request.Content == default ?
                await _endpoint.GetMessageAsync(request.Uri).ConfigureAwait(false) :
                await _endpoint.PostMessageAsync(request.Uri, MessageSerializer.Serialize(request.Content)).ConfigureAwait(false);
            Log(request, $"{response}, completed in {watch.ElapsedMilliseconds} ms");

            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            Log(request, $"Content: {content}");

            if (response.IsSuccessStatusCode)
                return content;

            try
            {
                var error = MessageSerializer.Deserialize<ClientError>(content, out _);
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
