using ClashOfClans.Core;
using ClashOfClans.Models;
using System;
using System.Threading.Tasks;

namespace ClashOfClans.Api
{
    internal class Clans : ClashOfClansBase, IClans
    {
        public Clans(string token, IThrottleRequests throttleRequests) :
            base(token, throttleRequests)
        {
        }

        // GET /clans
        public async Task<SearchResult> GetAsync(QueryClans query)
        {
            var uri = $"clans{query}";

            return await RequestAsync<SearchResult>(uri);
        }

        // GET /clans/{clanTag}
        public async Task<Clan> GetAsync(string clanTag)
        {
            var uri = $"clans/{clanTag}";

            return await RequestAsync<Clan>(uri);
        }

        // GET /clans/{clanTag}/members
        public async Task<ClanMemberList> GetMembersAsync(string clanTag, Query query = null)
        {
            var uri = $"clans/{clanTag}/members{query}";

            return await RequestAsync<ClanMemberList>(uri);
        }

        // GET /clans/{clanTag}/warlog
        public async Task<WarLog> GetWarLogAsync(string clanTag, Query query = null)
        {
            var uri = $"clans/{clanTag}/warlog{query}";

            return await RequestAsync<WarLog>(uri);
        }

        // GET /clans/{clanTag}/currentwar
        public async Task<CurrentWar> GetCurrentWarAsync(string clanTag)
        {
            var uri = $"clans/{clanTag}/currentwar";

            return await RequestAsync<CurrentWar>(uri);
        }

        // GET /clans/{clanTag}/currentwar/leaguegroup
        public async Task<CurrentWarLeagueGroup> GetCurrentWarLeagueGroupAsync(string clanTag)
        {
            var uri = $"clans/{clanTag}/currentwar/leaguegroup";

            return await RequestAsync<CurrentWarLeagueGroup>(uri);
        }

        // GET /clanwarleagues/wars/{warTag}
        public async Task<ClanWarLeagueWar> GetClanWarLeaguesWarsAsync(string warTag)
        {
            if (string.IsNullOrWhiteSpace(warTag) || warTag == "#0")
            {
                throw new ArgumentException(nameof(warTag));
            }

            var uri = $"clanwarleagues/wars/{warTag}";

            return await RequestAsync<ClanWarLeagueWar>(uri);
        }
    }
}
