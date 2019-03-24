﻿using ClashOfClans.Models;
using System.Threading.Tasks;

namespace ClashOfClans.Core
{
    public class Leagues : ClashOfClansBase, ILeagues
    {
        public Leagues(string token) : base(token)
        {
        }

        // GET /leagues
        public async Task<LeagueList> GetAsync(Query query = null)
        {
            var uri = $"leagues{query}";

            return await RequestAsync<LeagueList>(uri);
        }

        // GET /leagues/{leagueId}
        public async Task<League> GetAsync(int? leagueId)
        {
            var uri = $"leagues/{leagueId}";

            return await RequestAsync<League>(uri);
        }

        // GET /leagues/{leagueId}/seasons
        public async Task<LeagueSeasonList> GetSeasonsAsync(int? leagueId, Query query = null)
        {
            var uri = $"leagues/{leagueId}/seasons{query}";

            return await RequestAsync<LeagueSeasonList>(uri);
        }

        // GET /leagues/{leagueId}/seasons/{seasonId}
        public async Task<SeasonPlayerRankingList> GetSeasonsAsync(int? leagueId, string seasonId, Query query = null)
        {
            var uri = $"leagues/{leagueId}/seasons/{seasonId}{query}";

            return await RequestAsync<SeasonPlayerRankingList>(uri);
        }
    }
}