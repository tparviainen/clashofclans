using ClashOfClans.Core;
using ClashOfClans.Models;
using ClashOfClans.Validation;
using System.Threading.Tasks;

namespace ClashOfClans.Api
{
    internal class Players : IPlayers
    {
        private readonly IApiEndpoint _endpoint;
        private readonly Validator _validator;

        public Players(IApiEndpoint endpoint, Validator validator)
        {
            _endpoint = endpoint;
            _validator = validator;
        }

        // GET /players/{playerTag}
        public async Task<PlayerDetail> GetAsync(string playerTag)
        {
            _validator.ValidatePlayerTag(playerTag);

            var uri = $"players/{playerTag}";

            return await _endpoint.RequestAsync<PlayerDetail>(uri);
        }
    }
}
