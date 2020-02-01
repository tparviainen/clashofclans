using ClashOfClans.Core.Net;
using ClashOfClans.Core.Serialization;
using ClashOfClans.Models;
using ClashOfClans.Search;
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
            _endpoint = new ApiEndpoint(options.Tokens);
            _serializer = new MessageSerializer();
        }

        public async Task<T> RequestAsync<T>(AutoValidatedRequest request) where T : class
        {
            Log(request, $"Uri: /{request.Uri}");

            var data = await GetDataAsync(request).ConfigureAwait(false);

            var deserializedData = _serializer.Deserialize<T>(data);

            if (request.Query != null && IsGenericType<T>(typeof(QueryResult<>)))
            {
                var paging = GetPaging(deserializedData);
                request.Query.SetCursors(paging.Cursors);
            }

            return deserializedData;
        }

        private Paging GetPaging<T>(T data) =>
            data.GetType().GetProperty(nameof(QueryResult<object>.Paging)).GetValue(data) as Paging;

        private bool IsGenericType<TType>(System.Type type) =>
            typeof(TType).IsGenericType && typeof(TType).GetGenericTypeDefinition() == type;

        private async Task<string> GetDataAsync(AutoValidatedRequest request)
        {
            var watch = Stopwatch.StartNew();
            await _throttleRequests.WaitAsync().ConfigureAwait(false);
            Log(request, $"Throttling: {watch.ElapsedMilliseconds} ms");

            watch.Restart();
            var response = await _endpoint.GetMessageAsync(request.Uri).ConfigureAwait(false);
            Log(request, $"{response}, completed in {watch.ElapsedMilliseconds} ms");

            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
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
