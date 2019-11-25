using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ClashOfClans.Core.Net
{
    /// <summary>
    /// Represents a Clash of Clans game data REST API endpoint
    /// </summary>
    internal class ApiEndpoint
    {
        // HttpClient is intended to be instantiated once and re-used throughout the life of an application
        private static readonly HttpClient _client = new HttpClient();

        public ApiEndpoint(string token)
        {
            _client.BaseAddress = new Uri("https://api.clashofclans.com/v1/");

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<HttpResponseMessage> GetMessageAsync(string requestUri)
        {
            return await _client.GetAsync(requestUri);
        }
    }
}
