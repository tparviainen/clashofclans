using ClashOfClans.Core;
using ClashOfClans.Models;
using ClashOfClans.Search;
using System.Threading.Tasks;

namespace ClashOfClans.Api
{
    internal class Clans : ClashOfClansBase, IClans
    {
        public Clans(ClashOfClansOptionsInternal options) : base(options)
        {
        }

        // GET /clans
        public async Task<ClanList> GetAsync(QueryClans query)
        {
            _validator.ValidateQueryClans(query);

            var uri = $"clans{query}";

            return await RequestAsync<ClanList>(uri);
        }

        // GET /clans/{clanTag}
        public async Task<Clan> GetAsync(string clanTag)
        {
            _validator.ValidateClanTag(clanTag);

            var uri = $"clans/{clanTag}";

            return await RequestAsync<Clan>(uri);
        }

        // GET /clans/{clanTag}/members
        public async Task<ClanMemberList> GetMembersAsync(string clanTag, Query query = null)
        {
            _validator
                .ValidateClanTag(clanTag)
                .ValidateQuery(query);

            var uri = $"clans/{clanTag}/members{query}";

            return await RequestAsync<ClanMemberList>(uri);
        }

        // GET /clans/{clanTag}/warlog
        public async Task<ClanWarLog> GetWarLogAsync(string clanTag, Query query = null)
        {
            _validator
                .ValidateClanTag(clanTag)
                .ValidateQuery(query);

            var uri = $"clans/{clanTag}/warlog{query}";

            return await RequestAsync<ClanWarLog>(uri);
        }

        // GET /clans/{clanTag}/currentwar
        public async Task<CurrentWar> GetCurrentWarAsync(string clanTag)
        {
            _validator.ValidateClanTag(clanTag);

            var uri = $"clans/{clanTag}/currentwar";

            return await RequestAsync<CurrentWar>(uri);
        }

        // GET /clans/{clanTag}/currentwar/leaguegroup
        public async Task<CurrentWarLeagueGroup> GetCurrentWarLeagueGroupAsync(string clanTag)
        {
            _validator.ValidateClanTag(clanTag);

            var uri = $"clans/{clanTag}/currentwar/leaguegroup";

            return await RequestAsync<CurrentWarLeagueGroup>(uri);
        }

        // GET /clanwarleagues/wars/{warTag}
        public async Task<ClanWarLeagueWar> GetClanWarLeaguesWarsAsync(string warTag)
        {
            _validator.ValidateWarTag(warTag);

            var uri = $"clanwarleagues/wars/{warTag}";

            return await RequestAsync<ClanWarLeagueWar>(uri);
        }
    }
}
