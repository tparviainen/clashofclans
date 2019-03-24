using ClashOfClans.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace ClashOfClans.Tests
{
    [TestClass]
    public class LocationsTests : TestsBase
    {
        [TestMethod]
        public async Task ListLocations()
        {
            // Arrange
            var locations = new Locations(Token);

            // Act
            var locationList = await locations.GetAsync();

            // Assert
            Assert.IsNotNull(locationList);
        }

        [TestMethod]
        public async Task GetLocationInformation()
        {
            // Arrange
            var locations = new Locations(Token);
            var locationId = GetRandom(_locations).Id;

            // Act
            var location = await locations.GetAsync(locationId);

            // Assert
            Assert.IsNotNull(location);
        }

        [TestMethod]
        public async Task GetClanRankingsForASpecificLocation()
        {
            // Arrange
            var locations = new Locations(Token);
            var location = GetRandom(_locations);
            var query = new Query
            {
                Limit = 10
            };

            // Act
            var clanRankingList = await locations.GetRankingsClansAsync(location.Id, query);

            // Assert
            Assert.IsNotNull(clanRankingList);
        }

        [TestMethod]
        public async Task GetPlayerRankingsForASpecificLocation()
        {
            // Arrange
            var locations = new Locations(Token);
            var location = GetRandom(_locations);
            var query = new Query
            {
                Limit = 10
            };

            // Act
            var playerRankingList = await locations.GetRankingsPlayersAsync(location.Id, query);

            // Assert
            Assert.IsNotNull(playerRankingList);
        }

        [TestMethod]
        public async Task GetClanVersusRankingsForASpecificLocation()
        {
            // Arrange
            var locations = new Locations(Token);
            var location = GetRandom(_locations);
            var query = new Query
            {
                Limit = 10
            };

            // Act
            var clanRankingList = await locations.GetRankingsClansVersusAsync(location.Id, query);

            // Assert
            Assert.IsNotNull(clanRankingList);
        }

        [TestMethod]
        public async Task GetPlayerVersusRankingsForASpecificLocation()
        {
            // Arrange
            var locations = new Locations(Token);
            var locationId = GetRandom(_locations).Id;
            var query = new Query
            {
                Limit = 10
            };

            // Act
            var playerVersusRankingList = await locations.GetRankingsPlayersVersusAsync(locationId, query);

            // Assert
            Assert.IsNotNull(playerVersusRankingList);
        }
    }
}
