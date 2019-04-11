using ClashOfClans.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var leagueId = GetRandom(_leagueList.Items).Id;

            // Act
            var league = await leagues.GetAsync(leagueId);

            // Assert
            Assert.IsNotNull(league);
        }

        [TestMethod]
        public async Task GetLeagueSeasons()
        {
            // Arrange
            var league = _leagueList["Legend League"];

            // Act
            var leagueSeasonList = await _coc.Leagues.GetSeasonsAsync(league.Id);

            // Assert
            Assert.IsNotNull(leagueSeasonList);
        }

        [TestMethod]
        public async Task GetLeagueSeasonRankings()
        {
            // Arrange
            var league = _leagueList["Legend League"];
            var leagueSeasonList = await _coc.Leagues.GetSeasonsAsync(league.Id);
            var season = GetRandom(leagueSeasonList.Items);
            var query = new Query
            {
                Limit = 5
            };

            // Act
            var seasonPlayerRankingList = await _coc.Leagues.GetSeasonsAsync(league.Id, season.Id, query);

            // Assert
            Assert.IsNotNull(seasonPlayerRankingList);
        }
    }
}
