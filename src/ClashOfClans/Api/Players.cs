using ClashOfClans.Core;
using ClashOfClans.Models;
using System.Threading.Tasks;

namespace ClashOfClans.Api
{
    internal class Players : ClashOfClansBase, IPlayers
    {
        public Players(ClashOfClansOptionsInternal options) : base(options)
        {
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
