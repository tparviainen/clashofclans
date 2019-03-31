using ClashOfClans.Core;
using ClashOfClans.Models;
using System.Threading.Tasks;

namespace ClashOfClans.Api
{
    public class Locations : ClashOfClansBase, ILocations
    {
        public Locations(string token, IThrottleRequests throttleRequests) :
            base(token, throttleRequests)
        {
        }

        // GET /locations
        public async Task<LocationList> GetAsync(Query query = null)
        {
            var uri = $"locations{query}";

            return await RequestAsync<LocationList>(uri);
        }

        // GET /locations/{locationId}
        public async Task<Location> GetAsync(int? locationId)
        {
            var uri = $"locations/{locationId}";

            return await RequestAsync<Location>(uri);
        }

        // GET /locations/{locationId}/rankings/clans
        public async Task<ClanRankingList> GetRankingsClansAsync(int? locationId, Query query = null)
        {
            var uri = $"locations/{locationId}/rankings/clans{query}";

            return await RequestAsync<ClanRankingList>(uri);
        }

        // GET /locations/{locationId}/rankings/players
        public async Task<PlayerRankingList> GetRankingsPlayersAsync(int? locationId, Query query = null)
        {
            var uri = $"locations/{locationId}/rankings/players{query}";

            return await RequestAsync<PlayerRankingList>(uri);
        }

        // GET /locations/{locationId}/rankings/clans-versus
        public async Task<ClanRankingList> GetRankingsClansVersusAsync(int? locationId, Query query = null)
        {
            var uri = $"locations/{locationId}/rankings/clans-versus{query}";

            return await RequestAsync<ClanRankingList>(uri);
        }

        // GET /locations/{locationId}/rankings/players-versus
        public async Task<PlayerVersusRankingList> GetRankingsPlayersVersusAsync(int? locationId, Query query = null)
        {
            var uri = $"locations/{locationId}/rankings/players-versus{query}";

            return await RequestAsync<PlayerVersusRankingList>(uri);
        }
    }
}
