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

        public Task<QueryResult<LeagueList>> GetLeaguesAsync(Query query = null)
        {
            var request = new AutoValidatedRequest
            {
                Query = query,
                Uri = "/leagues"
            };

            return _gameData.RequestAsync<QueryResult<LeagueList>>(request);
        }

        public Task<League> GetLeagueAsync(int? leagueId)
        {
            var request = new AutoValidatedRequest
            {
                LeagueId = leagueId,
                Uri = $"/leagues/{leagueId}"
            };

            return _gameData.RequestAsync<League>(request);
        }

        public Task<QueryResult<LeagueSeasonList>> GetLeagueSeasonsAsync(int? leagueId, Query query = null)
        {
            var request = new AutoValidatedRequest
            {
                Query = query,
                LeagueId = leagueId,
                Uri = $"/leagues/{leagueId}/seasons"
            };

            return _gameData.RequestAsync<QueryResult<LeagueSeasonList>>(request);
        }

        public Task<QueryResult<PlayerRankingList>> GetLeagueSeasonRankingsAsync(int? leagueId, string seasonId, Query query = null)
        {
            var request = new AutoValidatedRequest
            {
                Query = query,
                LeagueId = leagueId,
                SeasonId = seasonId,
                Uri = $"/leagues/{leagueId}/seasons/{seasonId}"
            };

            return _gameData.RequestAsync<QueryResult<PlayerRankingList>>(request);
        }

        public Task<QueryResult<WarLeagueList>> GetWarLeaguesAsync(Query query = null)
        {
            var request = new AutoValidatedRequest
            {
                Query = query,
                Uri = $"/warleagues"
            };

            return _gameData.RequestAsync<QueryResult<WarLeagueList>>(request);
        }

        public Task<WarLeague> GetWarLeagueAsync(int? leagueId)
        {
            var request = new AutoValidatedRequest
            {
                LeagueId = leagueId,
                Uri = $"/warleagues/{leagueId}"
            };

            return _gameData.RequestAsync<WarLeague>(request);
        }
    }
}
