﻿using ClashOfClans.Models;
using ClashOfClans.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace ClashOfClans.Tests.Integration
{
    [TestClass]
    public class LeaguesTests : TestsBase
    {
        [TestMethod]
        public async Task ListLeagues()
        {
            // Arrange
            var leagues = _coc.Leagues;

            // Act
            var leagueList = (LeagueList)await leagues.GetLeaguesAsync();

            // Assert
            Assert.IsNotNull(leagueList);
        }

        [TestMethod]
        public async Task GetLeagueInformation()
        {
            // Arrange
            var leagues = _coc.Leagues;
            var leagueId = GetRandom(_leagues).Id;

            // Act
            var league = await leagues.GetLeagueAsync(leagueId);

            // Assert
            Assert.IsNotNull(league);
        }

        [TestMethod]
        public async Task GetLeagueSeasons()
        {
            // Arrange
            var league = _leagues["Legend League"];

            // Act
            var leagueSeasonList = (LeagueSeasonList)await _coc.Leagues.GetLeagueSeasonsAsync(league.Id);

            // Assert
            Assert.IsNotNull(leagueSeasonList);
        }

        [TestMethod]
        public async Task GetLeagueSeasonRankings()
        {
            // Arrange
            var league = _leagues["Legend League"];
            var leagueSeasonList = await _coc.Leagues.GetLeagueSeasonsAsync(league.Id);
            var season = GetRandom(leagueSeasonList.Items);
            var query = new Query
            {
                Limit = 5
            };

            // Act
            var seasonPlayerRankingList = (PlayerRankingList)await _coc.Leagues.GetLeagueSeasonRankingsAsync(league.Id, season.Id, query);

            // Assert
            Assert.IsNotNull(seasonPlayerRankingList);
        }

        [TestMethod]
        public async Task ListWarLeagues()
        {
            // Arrange
            var leagues = _coc.Leagues;

            // Act
            var warLeagueList = (WarLeagueList)await leagues.GetWarLeaguesAsync();

            // Assert
            Assert.IsNotNull(warLeagueList);
        }

        [TestMethod]
        public async Task GetWarLeagueInformation()
        {
            // Arrange
            var leagues = _coc.Leagues;
            var warLeagueId = GetRandom(_warLeagues).Id;

            // Act
            var warLeague = await leagues.GetWarLeagueAsync(warLeagueId);

            // Assert
            Assert.IsNotNull(warLeague);
        }
    }
}
