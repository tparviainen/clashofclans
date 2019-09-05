using ClashOfClans.Core;
using ClashOfClans.Models;
using ClashOfClans.Validation;
using System.Threading.Tasks;

namespace ClashOfClans.Api
{
    internal class Players : ClashOfClansBase, IPlayers
    {
        private readonly Validator _validator;

        public Players(ClashOfClansOptionsInternal options) : base(options)
        {
            _validator = options.Validator;
        }

        // GET /players/{playerTag}
        public async Task<PlayerDetail> GetAsync(string playerTag)
        {
            _validator.ValidatePlayerTag(playerTag);

            var uri = $"players/{playerTag}";

            return await RequestAsync<PlayerDetail>(uri);
        }
    }
}
