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
        public async Task<QueryResult<LocationList>> GetLocationsAsync(Query query = null)
        {
            _validator.ValidateQuery(query);

            var uri = $"locations{query}";

            return await _gameData.RequestAsync<QueryResult<LocationList>>(uri);
        }

        // GET /locations/{locationId}
        public async Task<Location> GetLocationAsync(int? locationId)
        {
            _validator.ValidateLocationId(locationId);

            var uri = $"locations/{locationId}";

            return await _gameData.RequestAsync<Location>(uri);
        }

        // GET /locations/{locationId}/rankings/clans
        public async Task<QueryResult<ClanRankingList>> GetClanRankingAsync(int? locationId, Query query = null)
        {
            _validator
                .ValidateLocationId(locationId)
                .ValidateQuery(query);

            var uri = $"locations/{locationId}/rankings/clans{query}";

            return await _gameData.RequestAsync<QueryResult<ClanRankingList>>(uri);
        }

        // GET /locations/{locationId}/rankings/players
        public async Task<QueryResult<PlayerRankingList>> GetPlayerRankingAsync(int? locationId, Query query = null)
        {
            _validator
                .ValidateLocationId(locationId)
                .ValidateQuery(query);

            var uri = $"locations/{locationId}/rankings/players{query}";

            return await _gameData.RequestAsync<QueryResult<PlayerRankingList>>(uri);
        }

        // GET /locations/{locationId}/rankings/clans-versus
        public async Task<QueryResult<ClanVersusRankingList>> GetClanVersusRankingAsync(int? locationId, Query query = null)
        {
            _validator
                .ValidateLocationId(locationId)
                .ValidateQuery(query);

            var uri = $"locations/{locationId}/rankings/clans-versus{query}";

            return await _gameData.RequestAsync<QueryResult<ClanVersusRankingList>>(uri);
        }

        // GET /locations/{locationId}/rankings/players-versus
        public async Task<QueryResult<PlayerVersusRankingList>> GetPlayerVersusRankingAsync(int? locationId, Query query = null)
        {
            _validator
                .ValidateLocationId(locationId)
                .ValidateQuery(query);

            var uri = $"locations/{locationId}/rankings/players-versus{query}";

            return await _gameData.RequestAsync<QueryResult<PlayerVersusRankingList>>(uri);
        }
    }
}
