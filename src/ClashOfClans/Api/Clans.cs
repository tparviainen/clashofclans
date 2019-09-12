﻿using ClashOfClans.Core;
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
        public async Task<ClanList> GetAsync(QueryClans query)
        {
            _validator.ValidateQueryClans(query);

            var uri = $"clans{query}";

            return await _gameData.RequestAsync<ClanList>(uri);
        }

        // GET /clans/{clanTag}
        public async Task<Clan> GetAsync(string clanTag)
        {
            _validator.ValidateClanTag(clanTag);

            var uri = $"clans/{clanTag}";

            return await _gameData.RequestAsync<Clan>(uri);
        }

        // GET /clans/{clanTag}/members
        public async Task<ClanMemberList> GetMembersAsync(string clanTag, Query query = null)
        {
            _validator
                .ValidateClanTag(clanTag)
                .ValidateQuery(query);

            var uri = $"clans/{clanTag}/members{query}";

            return await _gameData.RequestAsync<ClanMemberList>(uri);
        }

        // GET /clans/{clanTag}/warlog
        public async Task<ClanWarLog> GetWarLogAsync(string clanTag, Query query = null)
        {
            _validator
                .ValidateClanTag(clanTag)
                .ValidateQuery(query);

            var uri = $"clans/{clanTag}/warlog{query}";

            return await _gameData.RequestAsync<ClanWarLog>(uri);
        }

        // GET /clans/{clanTag}/currentwar
        public async Task<ClanWar> GetCurrentWarAsync(string clanTag)
        {
            _validator.ValidateClanTag(clanTag);

            var uri = $"clans/{clanTag}/currentwar";

            return await _gameData.RequestAsync<ClanWar>(uri);
        }

        // GET /clans/{clanTag}/currentwar/leaguegroup
        public async Task<ClanWarLeagueGroup> GetCurrentWarLeagueGroupAsync(string clanTag)
        {
            _validator.ValidateClanTag(clanTag);

            var uri = $"clans/{clanTag}/currentwar/leaguegroup";

            return await _gameData.RequestAsync<ClanWarLeagueGroup>(uri);
        }

        // GET /clanwarleagues/wars/{warTag}
        public async Task<ClanWarLeagueWar> GetClanWarLeaguesWarsAsync(string warTag)
        {
            _validator.ValidateWarTag(warTag);

            var uri = $"clanwarleagues/wars/{warTag}";

            return await _gameData.RequestAsync<ClanWarLeagueWar>(uri);
        }
    }
}
