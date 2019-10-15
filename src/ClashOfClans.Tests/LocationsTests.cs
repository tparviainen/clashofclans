using ClashOfClans.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace ClashOfClans.Tests
{
    [TestClass]
    public class LocationsTests : TestsBase
    {
        private readonly int ItemLimit = 10;

        [TestMethod]
        public async Task ListLocations()
        {
            // Arrange
            var locations = _coc.Locations;

            // Act
            var locationList = await locations.GetAsync();

            // Assert
            Assert.IsNotNull(locationList);
        }

        [TestMethod]
        public void LocationFinlandExists()
        {
            // Arrange

            // Act
            var finland = _locations["Finland"];

            // Assert
            Assert.IsNotNull(finland);
        }

        [TestMethod]
        public void LocationRepublicOfFinlandDoesNotExist()
        {
            // Arrange

            // Act
            var republicOfFinland = _locations["Republic of Finland"];

            // Assert
            Assert.IsNull(republicOfFinland);
        }

        [TestMethod]
        public async Task GetLocationInformation()
        {
            // Arrange
            var locationId = GetRandom(_locations.Items).Id;

            // Act
            var location = await _coc.Locations.GetAsync(locationId);

            // Assert
            Assert.IsNotNull(location);
        }

        [TestMethod]
        public async Task GetClanRankingsForASpecificLocation()
        {
            // Arrange
            var location = GetRandom(_locations.Items, l => l.IsCountry == true);
            var query = new Query
            {
                Limit = ItemLimit
            };

            // Act
            var clanRankingList = await _coc.Locations.GetRankingsClansAsync(location.Id, query);

            // Assert
            Assert.IsNotNull(clanRankingList);
            Assert.AreEqual(ItemLimit, clanRankingList.Items.Count, $"Id {location.Id}");
        }

        [TestMethod]
        public async Task GetPlayerRankingsForASpecificLocation()
        {
            // Arrange
            var location = GetRandom(_locations.Items, l => l.IsCountry == true);
            var query = new Query
            {
                Limit = ItemLimit
            };

            // Act
            var playerRankingList = await _coc.Locations.GetRankingsPlayersAsync(location.Id, query);

            // Assert
            Assert.IsNotNull(playerRankingList);
            Assert.IsTrue(playerRankingList.Items.Count <= ItemLimit, $"Id {location.Id}");
        }

        [TestMethod]
        public async Task GetClanVersusRankingsForASpecificLocation()
        {
            // Arrange
            var location = GetRandom(_locations.Items, l => l.IsCountry == true);
            var query = new Query
            {
                Limit = ItemLimit
            };

            // Act
            var clanRankingList = await _coc.Locations.GetRankingsClansVersusAsync(location.Id, query);

            // Assert
            Assert.IsNotNull(clanRankingList);
            Assert.AreEqual(ItemLimit, clanRankingList.Items.Count, $"Id {location.Id}");
        }

        [TestMethod]
        public async Task GetPlayerVersusRankingsForASpecificLocation()
        {
            // Arrange
            var location = GetRandom(_locations.Items, l => l.IsCountry == true);
            var query = new Query
            {
                Limit = ItemLimit
            };

            // Act
            var playerVersusRankingList = await _coc.Locations.GetRankingsPlayersVersusAsync(location.Id, query);

            // Assert
            Assert.IsNotNull(playerVersusRankingList);
            Assert.IsTrue(playerVersusRankingList.Items.Count <= ItemLimit, $"Id {location.Id}");
        }
    }
}
