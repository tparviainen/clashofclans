using ClashOfClans.Models;
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
            var league = _leagues["Legend League"]!;

            // Act
            var leagueSeasonList = (LeagueSeasonList)await _coc.Leagues.GetLeagueSeasonsAsync(league.Id);

            // Assert
            Assert.IsNotNull(leagueSeasonList);
        }

        [TestMethod]
        public async Task GetLeagueSeasonRankings()
        {
            // Arrange
            var league = _leagues["Legend League"]!;
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
            var warLeagues = (WarLeagueList)await _coc.Leagues.GetWarLeaguesAsync();
            var warLeagueId = GetRandom(warLeagues).Id;

            // Act
            var warLeague = await leagues.GetWarLeagueAsync(warLeagueId);

            // Assert
            Assert.IsNotNull(warLeague);
        }

        [TestMethod]
        public async Task ListCapitalLeagues()
        {
            // Arrange
            var leagues = _coc.Leagues;

            // Act
            var capitalLeagueList = (CapitalLeagueList)await leagues.GetCapitalLeaguesAsync();

            // Assert
            Assert.IsNotNull(capitalLeagueList);
        }

        [TestMethod]
        public async Task GetCapitalLeagueInformation()
        {
            // Arrange
            var leagues = _coc.Leagues;
            var capitalLeagues = (CapitalLeagueList)await _coc.Leagues.GetCapitalLeaguesAsync();
            var capitalLeagueId = GetRandom(capitalLeagues).Id;

            // Act
            var capitalLeague = await leagues.GetCapitalLeagueAsync(capitalLeagueId);

            // Assert
            Assert.IsNotNull(capitalLeague);
        }

        [TestMethod]
        public async Task ListBuilderBaseLeagues()
        {
            // Arrange
            var leagues = _coc.Leagues;

            // Act
            var builderBaseLeagueList = (BuilderBaseLeagueList)await leagues.GetBuilderBaseLeaguesAsync();

            // Assert
            Assert.IsNotNull(builderBaseLeagueList);
        }

        [TestMethod]
        public async Task GetBuilderBaseLeagueInformation()
        {
            // Arrange
            var leagues = _coc.Leagues;
            var builderBaseLeagues = (BuilderBaseLeagueList)await leagues.GetBuilderBaseLeaguesAsync();
            var builderBaseLeagueId = GetRandom(builderBaseLeagues).Id;

            // Act
            var builderBaseLeague = await leagues.GetBuilderBaseLeagueAsync(builderBaseLeagueId);

            // Assert
            Assert.IsNotNull(builderBaseLeague);
        }
    }
}
