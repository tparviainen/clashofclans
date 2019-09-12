using ClashOfClans.Core;
using ClashOfClans.Models;
using ClashOfClans.Search;
using ClashOfClans.Validation;
using System.Threading.Tasks;

namespace ClashOfClans.Api
{
    internal class Locations : ILocations
    {
        private readonly IGameData _gameData;
        private readonly Validator _validator;

        public Locations(IGameData gameData, Validator validator)
        {
            _gameData = gameData;
            _validator = validator;
        }

        // GET /locations
        public async Task<LocationList> GetAsync(Query query = null)
        {
            _validator.ValidateQuery(query);

            var uri = $"locations{query}";

            return await _gameData.RequestAsync<LocationList>(uri);
        }

        // GET /locations/{locationId}
        public async Task<Location> GetAsync(int? locationId)
        {
            _validator.ValidateLocationId(locationId);

            var uri = $"locations/{locationId}";

            return await _gameData.RequestAsync<Location>(uri);
        }

        // GET /locations/{locationId}/rankings/clans
        public async Task<ClanRankingList> GetRankingsClansAsync(int? locationId, Query query = null)
        {
            _validator
                .ValidateLocationId(locationId)
                .ValidateQuery(query);

            var uri = $"locations/{locationId}/rankings/clans{query}";

            return await _gameData.RequestAsync<ClanRankingList>(uri);
        }

        // GET /locations/{locationId}/rankings/players
        public async Task<PlayerRankingList> GetRankingsPlayersAsync(int? locationId, Query query = null)
        {
            _validator
                .ValidateLocationId(locationId)
                .ValidateQuery(query);

            var uri = $"locations/{locationId}/rankings/players{query}";

            return await _gameData.RequestAsync<PlayerRankingList>(uri);
        }

        // GET /locations/{locationId}/rankings/clans-versus
        public async Task<ClanVersusRankingList> GetRankingsClansVersusAsync(int? locationId, Query query = null)
        {
            _validator
                .ValidateLocationId(locationId)
                .ValidateQuery(query);

            var uri = $"locations/{locationId}/rankings/clans-versus{query}";

            return await _gameData.RequestAsync<ClanVersusRankingList>(uri);
        }

        // GET /locations/{locationId}/rankings/players-versus
        public async Task<PlayerVersusRankingList> GetRankingsPlayersVersusAsync(int? locationId, Query query = null)
        {
            _validator
                .ValidateLocationId(locationId)
                .ValidateQuery(query);

            var uri = $"locations/{locationId}/rankings/players-versus{query}";

            return await _gameData.RequestAsync<PlayerVersusRankingList>(uri);
        }
    }
}
