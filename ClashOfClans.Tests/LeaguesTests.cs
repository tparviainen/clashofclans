using ClashOfClans.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace ClashOfClans.Tests
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
            var leagueList = await leagues.GetAsync();

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
            var league = await leagues.GetAsync(leagueId);

            // Assert
            Assert.IsNotNull(league);
        }

        [TestMethod]
        public async Task GetLeagueSeasons()
        {
            // Arrange
            var leagues = _coc.Leagues;
            var leagueId = _leagues.Where(l => l.Name == LegendLeague).Single().Id;

            // Act
            var leagueSeasonList = await leagues.GetSeasonsAsync(leagueId);

            // Assert
            Assert.IsNotNull(leagueSeasonList);
        }

        [TestMethod]
        public async Task GetLeagueSeasonRankings()
        {
            // Arrange
            var leagues = _coc.Leagues;
            var leagueId = _leagues.Where(l => l.Name == LegendLeague).Single().Id;
            var leagueSeasonList = await leagues.GetSeasonsAsync(leagueId);
            var seasonId = GetRandom(leagueSeasonList.Items).Id;
            var query = new Query
            {
                Limit = 5
            };

            // Act
            var seasonPlayerRankingList = await leagues.GetSeasonsAsync(leagueId, seasonId, query);

            // Assert
            Assert.IsNotNull(seasonPlayerRankingList);
        }
    }
}
