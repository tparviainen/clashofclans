using ClashOfClans.Core;
using ClashOfClans.Models;
using ClashOfClans.Search;
using System.Threading.Tasks;

namespace ClashOfClans.Api
{
    internal class Leagues : ILeagues
    {
        private readonly IGameData _gameData;

        public Leagues(IGameData gameData)
        {
            _gameData = gameData;
        }

        public async Task<QueryResult<LeagueList>> GetLeaguesAsync(Query query = null)
        {
            var request = new AutoValidatedRequest
            {
                Query = query,
                Uri = "/leagues"
            };

            return await _gameData.RequestAsync<QueryResult<LeagueList>>(request);
        }

        public async Task<League> GetLeagueAsync(int? leagueId)
        {
            var request = new AutoValidatedRequest
            {
                LeagueId = leagueId,
                Uri = $"/leagues/{leagueId}"
            };

            return await _gameData.RequestAsync<League>(request);
        }

        public async Task<QueryResult<LeagueSeasonList>> GetLeagueSeasonsAsync(int? leagueId, Query query = null)
        {
            var request = new AutoValidatedRequest
            {
                Query = query,
                LeagueId = leagueId,
                Uri = $"/leagues/{leagueId}/seasons"
            };

            return await _gameData.RequestAsync<QueryResult<LeagueSeasonList>>(request);
        }

        public async Task<QueryResult<PlayerRankingList>> GetLeagueSeasonRankingsAsync(int? leagueId, string seasonId, Query query = null)
        {
            var request = new AutoValidatedRequest
            {
                Query = query,
                LeagueId = leagueId,
                SeasonId = seasonId,
                Uri = $"/leagues/{leagueId}/seasons/{seasonId}"
            };

            return await _gameData.RequestAsync<QueryResult<PlayerRankingList>>(request);
        }
    }
}
