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

        public Task<QueryResult<ClanList>> SearchClansAsync(QueryClans query)
        {
            var request = new AutoValidatedRequest
            {
                QueryClans = query,
                Uri = "/clans"
            };

            return _gameData.RequestAsync<QueryResult<ClanList>>(request);
        }

        public Task<Clan> GetClanAsync(string clanTag)
        {
            var request = new AutoValidatedRequest
            {
                ClanTag = clanTag,
                Uri = $"/clans/{clanTag}"
            };

            return _gameData.RequestAsync<Clan>(request);
        }

        public Task<QueryResult<ClanMemberList>> GetClanMembersAsync(string clanTag, Query query = null)
        {
            var request = new AutoValidatedRequest
            {
                Query = query,
                ClanTag = clanTag,
                Uri = $"/clans/{clanTag}/members"
            };

            return _gameData.RequestAsync<QueryResult<ClanMemberList>>(request);
        }

        public Task<QueryResult<ClanWarLog>> GetClanWarLogAsync(string clanTag, Query query = null)
        {
            var request = new AutoValidatedRequest
            {
                Query = query,
                ClanTag = clanTag,
                Uri = $"/clans/{clanTag}/warlog"
            };

            return _gameData.RequestAsync<QueryResult<ClanWarLog>>(request);
        }

        public Task<ClanWar> GetCurrentWarAsync(string clanTag)
        {
            var request = new AutoValidatedRequest
            {
                ClanTag = clanTag,
                Uri = $"/clans/{clanTag}/currentwar"
            };

            return _gameData.RequestAsync<ClanWar>(request);
        }

        public Task<ClanWarLeagueGroup> GetClanWarLeagueGroupAsync(string clanTag)
        {
            var request = new AutoValidatedRequest
            {
                ClanTag = clanTag,
                Uri = $"/clans/{clanTag}/currentwar/leaguegroup"
            };

            return _gameData.RequestAsync<ClanWarLeagueGroup>(request);
        }

        public Task<ClanWarLeagueWar> GetClanWarLeagueWarAsync(string warTag)
        {
            var request = new AutoValidatedRequest
            {
                WarTag = warTag,
                Uri = $"/clanwarleagues/wars/{warTag}"
            };

            return _gameData.RequestAsync<ClanWarLeagueWar>(request);
        }
    }
}
