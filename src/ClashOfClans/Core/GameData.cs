using ClashOfClans.Core.Net;
using ClashOfClans.Core.Serialization;
using ClashOfClans.Extensions;
using ClashOfClans.Models;
using ClashOfClans.Search;
using System;
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
        private readonly MessageSerializer _serializer;
        private readonly ClashOfClansOptionsInternal _options;
        private IThrottleRequests ThrottleRequests => _options.ThrottleRequests;

#if DEBUG
        private readonly NullableTypes _nullableTypes = new NullableTypes();
#endif

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

        public async Task<QueryResult<T>> QueryAsync<T>(AutoValidatedRequest request) where T : class
        {
            var deserializedData = await RequestAsync<QueryResult<T>>(request).ConfigureAwait(false);

            if (request.Query != null)
                request.Query.SetCursors(deserializedData.Paging.Cursors);

            return deserializedData;
        }

        public async Task<T> RequestAsync<T>(AutoValidatedRequest request) where T : class
        {
            Log(request, $"Uri: /{request.Uri}");

            var data = await GetDataAsync(request).ConfigureAwait(false);
            var deserializedData = _serializer.Deserialize<T>(data);

#if DEBUG
            lock (_nullableTypes)
            {
                var nullProperties = deserializedData.GetNullMembers();
                _nullableTypes.Add(nullProperties);
                var nullableTypes = _nullableTypes.GetUncheckedNulls();
                if (nullableTypes != default)
                {
                    var today = DateTime.Now.ToShortDateString();
                    var properties = string.Join(Environment.NewLine, nullableTypes.Select(kvp => $"{kvp.Key}, {today}, total {kvp.Value}"));
                    Log(request, $"Aggregate list of null properties:{Environment.NewLine + properties}");
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
                await _endpoint.PostMessageAsync(request.Uri, _serializer.Serialize(request.Content)).ConfigureAwait(false);
            Log(request, $"{response}, completed in {watch.ElapsedMilliseconds} ms");

            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            Log(request, $"Content: {content}");

            if (response.IsSuccessStatusCode)
                return content;

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
