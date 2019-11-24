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

        public async Task<QueryResult<LocationList>> GetLocationsAsync(Query query = null)
        {
            var request = new AutoValidatedRequest
            {
                Query = query,
                Uri = "/locations"
            };

            return await _gameData.RequestAsync<QueryResult<LocationList>>(request);
        }

        public async Task<Location> GetLocationAsync(int? locationId)
        {
            var request = new AutoValidatedRequest
            {
                LocationId = locationId,
                Uri = $"/locations/{locationId}"
            };

            return await _gameData.RequestAsync<Location>(request);
        }

        public async Task<QueryResult<ClanRankingList>> GetClanRankingAsync(int? locationId, Query query = null)
        {
            var request = new AutoValidatedRequest
            {
                Query = query,
                LocationId = locationId,
                Uri = $"/locations/{locationId}/rankings/clans"
            };

            return await _gameData.RequestAsync<QueryResult<ClanRankingList>>(request);
        }

        public async Task<QueryResult<PlayerRankingList>> GetPlayerRankingAsync(int? locationId, Query query = null)
        {
            var request = new AutoValidatedRequest
            {
                Query = query,
                LocationId = locationId,
                Uri = $"/locations/{locationId}/rankings/players"
            };

            return await _gameData.RequestAsync<QueryResult<PlayerRankingList>>(request);
        }

        public async Task<QueryResult<ClanVersusRankingList>> GetClanVersusRankingAsync(int? locationId, Query query = null)
        {
            var request = new AutoValidatedRequest
            {
                Query = query,
                LocationId = locationId,
                Uri = $"/locations/{locationId}/rankings/clans-versus"
            };

            return await _gameData.RequestAsync<QueryResult<ClanVersusRankingList>>(request);
        }

        public async Task<QueryResult<PlayerVersusRankingList>> GetPlayerVersusRankingAsync(int? locationId, Query query = null)
        {
            var request = new AutoValidatedRequest
            {
                Query = query,
                LocationId = locationId,
                Uri = $"/locations/{locationId}/rankings/players-versus"
            };

            return await _gameData.RequestAsync<QueryResult<PlayerVersusRankingList>>(request);
        }
    }
}
