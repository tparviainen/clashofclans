using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ClashOfClans.Core.Net
{
    internal class ApiClient
    {
        private readonly AuthenticationHeaderValue _authorization;
        private readonly Uri _baseAddress = new Uri("https://api.clashofclans.com/v1/");

        public ApiClient(string token)
        {
            _authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<HttpResponseMessage> GetMessageAsync(string requestUri)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = _baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = _authorization;

                return await client.GetAsync(requestUri);
            }
        }
    }
}
