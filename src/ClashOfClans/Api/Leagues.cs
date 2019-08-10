﻿using ClashOfClans.Core;
using ClashOfClans.Models;
using ClashOfClans.Search;
using System.Threading.Tasks;

namespace ClashOfClans.Api
{
    internal class Leagues : ClashOfClansBase, ILeagues
    {
        public Leagues(ClashOfClansOptionsInternal options) : base(options)
        {
        }

        // GET /leagues
        public async Task<LeagueList> GetAsync(Query query = null)
        {
            _validator.ValidateQuery(query);

            var uri = $"leagues{query}";

            return await RequestAsync<LeagueList>(uri);
        }

        // GET /leagues/{leagueId}
        public async Task<League> GetAsync(int? leagueId)
        {
            _validator.ValidateLeagueId(leagueId);

            var uri = $"leagues/{leagueId}";

            return await RequestAsync<League>(uri);
        }

        // GET /leagues/{leagueId}/seasons
        public async Task<LeagueSeasonList> GetSeasonsAsync(int? leagueId, Query query = null)
        {
            _validator
                .ValidateLeagueId(leagueId)
                .ValidateQuery(query);

            var uri = $"leagues/{leagueId}/seasons{query}";

            return await RequestAsync<LeagueSeasonList>(uri);
        }

        // GET /leagues/{leagueId}/seasons/{seasonId}
        public async Task<SeasonPlayerRankingList> GetSeasonsAsync(int? leagueId, string seasonId, Query query = null)
        {
            _validator
                .ValidateLeagueId(leagueId)
                .ValidateSeasonId(seasonId)
                .ValidateQuery(query);

            var uri = $"leagues/{leagueId}/seasons/{seasonId}{query}";

            return await RequestAsync<SeasonPlayerRankingList>(uri);
        }
    }
}
