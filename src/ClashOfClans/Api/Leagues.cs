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

        public Task<QueryResult<LeagueList>> GetLeaguesAsync(Query? query = default)
        {
            var request = new AutoValidatedRequest
            {
                Query = query,
                Uri = "/leagues"
            };

            return _gameData.QueryAsync<LeagueList>(request);
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

        public Task<QueryResult<LeagueSeasonList>> GetLeagueSeasonsAsync(int? leagueId, Query? query = default)
        {
            var request = new AutoValidatedRequest
            {
                Query = query,
                LeagueId = leagueId,
                Uri = $"/leagues/{leagueId}/seasons"
            };

            return _gameData.QueryAsync<LeagueSeasonList>(request);
        }

        public Task<QueryResult<PlayerRankingList>> GetLeagueSeasonRankingsAsync(int? leagueId, string seasonId, Query? query = default)
        {
            var request = new AutoValidatedRequest
            {
                Query = query,
                LeagueId = leagueId,
                SeasonId = seasonId,
                Uri = $"/leagues/{leagueId}/seasons/{seasonId}"
            };

            return _gameData.QueryAsync<PlayerRankingList>(request);
        }

        public Task<QueryResult<WarLeagueList>> GetWarLeaguesAsync(Query? query = default)
        {
            var request = new AutoValidatedRequest
            {
                Query = query,
                Uri = $"/warleagues"
            };

            return _gameData.QueryAsync<WarLeagueList>(request);
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

        public Task<QueryResult<CapitalLeagueList>> GetCapitalLeaguesAsync(Query? query = default)
        {
            var request = new AutoValidatedRequest
            {
                Query = query,
                Uri = $"/capitalleagues"
            };

            return _gameData.QueryAsync<CapitalLeagueList>(request);
        }

        public Task<CapitalLeague> GetCapitalLeagueAsync(int? leagueId)
        {
            var request = new AutoValidatedRequest
            {
                LeagueId = leagueId,
                Uri = $"/capitalleagues/{leagueId}"
            };

            return _gameData.RequestAsync<CapitalLeague>(request);
        }
    }
}
