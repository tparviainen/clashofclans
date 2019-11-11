using ClashOfClans.Core;
using ClashOfClans.Models;
using ClashOfClans.Search;
using ClashOfClans.Validation;
using System.Threading.Tasks;

namespace ClashOfClans.Api
{
    internal class Clans : IClans
    {
        private readonly IGameData _gameData;
        private readonly Validator _validator;

        public Clans(IGameData gameData, Validator validator)
        {
            _gameData = gameData;
            _validator = validator;
        }

        // GET /clans
        public async Task<QueryResult<ClanList>> SearchClansAsync(QueryClans query)
        {
            _validator.ValidateQueryClans(query);

            var uri = $"clans{query}";

            return await _gameData.RequestAsync<QueryResult<ClanList>>(uri);
        }

        // GET /clans/{clanTag}
        public async Task<Clan> GetClanAsync(string clanTag)
        {
            _validator.ValidateClanTag(clanTag);

            var uri = $"clans/{clanTag}";

            return await _gameData.RequestAsync<Clan>(uri);
        }

        // GET /clans/{clanTag}/members
        public async Task<QueryResult<ClanMemberList>> GetClanMembersAsync(string clanTag, Query query = null)
        {
            _validator
                .ValidateClanTag(clanTag)
                .ValidateQuery(query);

            var uri = $"clans/{clanTag}/members{query}";

            return await _gameData.RequestAsync<QueryResult<ClanMemberList>>(uri);
        }

        // GET /clans/{clanTag}/warlog
        public async Task<QueryResult<ClanWarLog>> GetClanWarLogAsync(string clanTag, Query query = null)
        {
            _validator
                .ValidateClanTag(clanTag)
                .ValidateQuery(query);

            var uri = $"clans/{clanTag}/warlog{query}";

            return await _gameData.RequestAsync<QueryResult<ClanWarLog>>(uri);
        }

        // GET /clans/{clanTag}/currentwar
        public async Task<ClanWar> GetCurrentWarAsync(string clanTag)
        {
            _validator.ValidateClanTag(clanTag);

            var uri = $"clans/{clanTag}/currentwar";

            return await _gameData.RequestAsync<ClanWar>(uri);
        }

        // GET /clans/{clanTag}/currentwar/leaguegroup
        public async Task<ClanWarLeagueGroup> GetClanWarLeagueGroupAsync(string clanTag)
        {
            _validator.ValidateClanTag(clanTag);

            var uri = $"clans/{clanTag}/currentwar/leaguegroup";

            return await _gameData.RequestAsync<ClanWarLeagueGroup>(uri);
        }

        // GET /clanwarleagues/wars/{warTag}
        public async Task<ClanWarLeagueWar> GetClanWarLeagueWarAsync(string warTag)
        {
            _validator.ValidateWarTag(warTag);

            var uri = $"clanwarleagues/wars/{warTag}";

            return await _gameData.RequestAsync<ClanWarLeagueWar>(uri);
        }
    }
}
