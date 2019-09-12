using ClashOfClans.Core;
using ClashOfClans.Models;
using ClashOfClans.Search;
using ClashOfClans.Validation;
using System.Threading.Tasks;

namespace ClashOfClans.Api
{
    internal class Leagues : ILeagues
    {
        private readonly IGameData _gameData;
        private readonly Validator _validator;

        public Leagues(IGameData gameData, Validator validator)
        {
            _gameData = gameData;
            _validator = validator;
        }

        // GET /leagues
        public async Task<LeagueList> GetAsync(Query query = null)
        {
            _validator.ValidateQuery(query);

            var uri = $"leagues{query}";

            return await _gameData.RequestAsync<LeagueList>(uri);
        }

        // GET /leagues/{leagueId}
        public async Task<League> GetAsync(int? leagueId)
        {
            _validator.ValidateLeagueId(leagueId);

            var uri = $"leagues/{leagueId}";

            return await _gameData.RequestAsync<League>(uri);
        }

        // GET /leagues/{leagueId}/seasons
        public async Task<LeagueSeasonList> GetSeasonsAsync(int? leagueId, Query query = null)
        {
            _validator
                .ValidateLeagueId(leagueId)
                .ValidateQuery(query);

            var uri = $"leagues/{leagueId}/seasons{query}";

            return await _gameData.RequestAsync<LeagueSeasonList>(uri);
        }

        // GET /leagues/{leagueId}/seasons/{seasonId}
        public async Task<PlayerRankingList> GetSeasonsAsync(int? leagueId, string seasonId, Query query = null)
        {
            _validator
                .ValidateLeagueId(leagueId)
                .ValidateSeasonId(seasonId)
                .ValidateQuery(query);

            var uri = $"leagues/{leagueId}/seasons/{seasonId}{query}";

            return await _gameData.RequestAsync<PlayerRankingList>(uri);
        }
    }
}
