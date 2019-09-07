using ClashOfClans.Core;
using ClashOfClans.Models;
using ClashOfClans.Search;
using ClashOfClans.Validation;
using System.Threading.Tasks;

namespace ClashOfClans.Api
{
    internal class Clans : IClans
    {
        private readonly IApiEndpoint _endpoint;
        private readonly Validator _validator;

        public Clans(IApiEndpoint endpoint, Validator validator)
        {
            _endpoint = endpoint;
            _validator = validator;
        }

        // GET /clans
        public async Task<SearchResult> GetAsync(QueryClans query)
        {
            _validator.ValidateQueryClans(query);

            var uri = $"clans{query}";

            return await _endpoint.RequestAsync<SearchResult>(uri);
        }

        // GET /clans/{clanTag}
        public async Task<Clan> GetAsync(string clanTag)
        {
            _validator.ValidateClanTag(clanTag);

            var uri = $"clans/{clanTag}";

            return await _endpoint.RequestAsync<Clan>(uri);
        }

        // GET /clans/{clanTag}/members
        public async Task<ClanMemberList> GetMembersAsync(string clanTag, Query query = null)
        {
            _validator
                .ValidateClanTag(clanTag)
                .ValidateQuery(query);

            var uri = $"clans/{clanTag}/members{query}";

            return await _endpoint.RequestAsync<ClanMemberList>(uri);
        }

        // GET /clans/{clanTag}/warlog
        public async Task<WarLog> GetWarLogAsync(string clanTag, Query query = null)
        {
            _validator
                .ValidateClanTag(clanTag)
                .ValidateQuery(query);

            var uri = $"clans/{clanTag}/warlog{query}";

            return await _endpoint.RequestAsync<WarLog>(uri);
        }

        // GET /clans/{clanTag}/currentwar
        public async Task<CurrentWar> GetCurrentWarAsync(string clanTag)
        {
            _validator.ValidateClanTag(clanTag);

            var uri = $"clans/{clanTag}/currentwar";

            return await _endpoint.RequestAsync<CurrentWar>(uri);
        }

        // GET /clans/{clanTag}/currentwar/leaguegroup
        public async Task<CurrentWarLeagueGroup> GetCurrentWarLeagueGroupAsync(string clanTag)
        {
            _validator.ValidateClanTag(clanTag);

            var uri = $"clans/{clanTag}/currentwar/leaguegroup";

            return await _endpoint.RequestAsync<CurrentWarLeagueGroup>(uri);
        }

        // GET /clanwarleagues/wars/{warTag}
        public async Task<ClanWarLeagueWar> GetClanWarLeaguesWarsAsync(string warTag)
        {
            _validator.ValidateWarTag(warTag);

            var uri = $"clanwarleagues/wars/{warTag}";

            return await _endpoint.RequestAsync<ClanWarLeagueWar>(uri);
        }
    }
}
