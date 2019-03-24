using ClashOfClans.Models;
using System;
using System.Threading.Tasks;

namespace ClashOfClans.Core
{
    public class Players : ClashOfClansBase, IPlayers
    {
        public Players(string token) : base(token)
        {
        }

        // GET /players/{playerTag}
        public async Task<PlayerDetail> GetAsync(string playerTag)
        {
            if (string.IsNullOrWhiteSpace(playerTag))
            {
                throw new ArgumentNullException(nameof(playerTag));
            }

            var uri = $"players/{playerTag}";

            return await RequestAsync<PlayerDetail>(uri);
        }
    }
}
