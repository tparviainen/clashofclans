using ClashOfClans.Core;
using ClashOfClans.Models;
using ClashOfClans.Search;
using System.Threading.Tasks;

namespace ClashOfClans.Api
{
    internal class Locations : ILocations
    {
        private readonly IGameData _gameData;

        public Locations(IGameData gameData)
        {
            _gameData = gameData;
        }

        public Task<QueryResult<LocationList>> GetLocationsAsync(Query? query = default)
        {
            var request = new AutoValidatedRequest
            {
                Query = query,
                Uri = "/locations"
            };

            return _gameData.QueryAsync<LocationList>(request);
        }

        public Task<Location> GetLocationAsync(int? locationId)
        {
            var request = new AutoValidatedRequest
            {
                LocationId = locationId,
                Uri = $"/locations/{locationId}"
            };

            return _gameData.RequestAsync<Location>(request);
        }

        public Task<QueryResult<ClanRankingList>> GetClanRankingAsync(int? locationId, Query? query = default)
        {
            var request = new AutoValidatedRequest
            {
                Query = query,
                LocationId = locationId,
                Uri = $"/locations/{locationId}/rankings/clans"
            };

            return _gameData.QueryAsync<ClanRankingList>(request);
        }

        public Task<QueryResult<PlayerRankingList>> GetPlayerRankingAsync(int? locationId, Query? query = default)
        {
            var request = new AutoValidatedRequest
            {
                Query = query,
                LocationId = locationId,
                Uri = $"/locations/{locationId}/rankings/players"
            };

            return _gameData.QueryAsync<PlayerRankingList>(request);
        }

        public Task<QueryResult<ClanVersusRankingList>> GetClanVersusRankingAsync(int? locationId, Query? query = default)
        {
            var request = new AutoValidatedRequest
            {
                Query = query,
                LocationId = locationId,
                Uri = $"/locations/{locationId}/rankings/clans-versus"
            };

            return _gameData.QueryAsync<ClanVersusRankingList>(request);
        }

        public Task<QueryResult<PlayerVersusRankingList>> GetPlayerVersusRankingAsync(int? locationId, Query? query = default)
        {
            var request = new AutoValidatedRequest
            {
                Query = query,
                LocationId = locationId,
                Uri = $"/locations/{locationId}/rankings/players-versus"
            };

            return _gameData.QueryAsync<PlayerVersusRankingList>(request);
        }
    }
}
