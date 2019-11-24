using ClashOfClans.Core;
using ClashOfClans.Models;
using ClashOfClans.Search;
using System.Threading.Tasks;

namespace ClashOfClans.Api
{
    internal class Clans : IClans
    {
        private readonly IGameData _gameData;

        public Clans(IGameData gameData)
        {
            _gameData = gameData;
        }

        public async Task<QueryResult<ClanList>> SearchClansAsync(QueryClans query)
        {
            var request = new AutoValidatedRequest
            {
                QueryClans = query,
                Uri = $"/clans{query}"
            };

            return await _gameData.RequestAsync<QueryResult<ClanList>>(request);
        }

        public async Task<Clan> GetClanAsync(string clanTag)
        {
            var request = new AutoValidatedRequest
            {
                ClanTag = clanTag,
                Uri = $"/clans/{clanTag}"
            };

            return await _gameData.RequestAsync<Clan>(request);
        }

        public async Task<QueryResult<ClanMemberList>> GetClanMembersAsync(string clanTag, Query query = null)
        {
            var request = new AutoValidatedRequest
            {
                Query = query,
                ClanTag = clanTag,
                Uri = $"/clans/{clanTag}/members{query}"
            };

            return await _gameData.RequestAsync<QueryResult<ClanMemberList>>(request);
        }

        public async Task<QueryResult<ClanWarLog>> GetClanWarLogAsync(string clanTag, Query query = null)
        {
            var request = new AutoValidatedRequest
            {
                Query = query,
                ClanTag = clanTag,
                Uri = $"/clans/{clanTag}/warlog{query}"
            };

            return await _gameData.RequestAsync<QueryResult<ClanWarLog>>(request);
        }

        public async Task<ClanWar> GetCurrentWarAsync(string clanTag)
        {
            var request = new AutoValidatedRequest
            {
                ClanTag = clanTag,
                Uri = $"/clans/{clanTag}/currentwar"
            };

            return await _gameData.RequestAsync<ClanWar>(request);
        }

        public async Task<ClanWarLeagueGroup> GetClanWarLeagueGroupAsync(string clanTag)
        {
            var request = new AutoValidatedRequest
            {
                ClanTag = clanTag,
                Uri = $"/clans/{clanTag}/currentwar/leaguegroup"
            };

            return await _gameData.RequestAsync<ClanWarLeagueGroup>(request);
        }

        public async Task<ClanWarLeagueWar> GetClanWarLeagueWarAsync(string warTag)
        {
            var request = new AutoValidatedRequest
            {
                WarTag = warTag,
                Uri = $"/clanwarleagues/wars/{warTag}"
            };

            return await _gameData.RequestAsync<ClanWarLeagueWar>(request);
        }
    }
}
