using ClashOfClans.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace ClashOfClans.Tests
{
    [TestClass]
    public class LocationsTests : TestsBase
    {
        private int ItemLimit = 10;

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
        public async Task LocationFinlandExists()
        {
            // Arrange
            var locations = _coc.Locations;
            var locationList = await locations.GetAsync();

            // Act
            var finland = locationList["Finland"];

            // Assert
            Assert.IsNotNull(finland);
        }

        [TestMethod]
        public async Task LocationRepublicOfFinlandDoesNotExist()
        {
            // Arrange
            var locations = _coc.Locations;
            var locationList = await locations.GetAsync();

            // Act
            var republicOfFinland = locationList["Republic of Finland"];

            // Assert
            Assert.IsNull(republicOfFinland);
        }

        [TestMethod]
        public async Task GetLocationInformation()
        {
            // Arrange
            var locations = _coc.Locations;
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
            var locations = _coc.Locations;
            var location = GetRandom(_locations, l => l.IsCountry == true);
            var query = new Query
            {
                Limit = ItemLimit
            };

            // Act
            var clanRankingList = await locations.GetRankingsClansAsync(location.Id, query);

            // Assert
            Assert.IsNotNull(clanRankingList);
            Assert.AreEqual(ItemLimit, clanRankingList.Items.Length, $"Id {location.Id}");
        }

        [TestMethod]
        public async Task GetPlayerRankingsForASpecificLocation()
        {
            // Arrange
            var locations = _coc.Locations;
            var location = GetRandom(_locations, l => l.IsCountry == true);
            var query = new Query
            {
                Limit = ItemLimit
            };

            // Act
            var playerRankingList = await locations.GetRankingsPlayersAsync(location.Id, query);

            // Assert
            Assert.IsNotNull(playerRankingList);
            Assert.IsTrue(playerRankingList.Items.Length <= ItemLimit, $"Id {location.Id}");
        }

        [TestMethod]
        public async Task GetClanVersusRankingsForASpecificLocation()
        {
            // Arrange
            var locations = _coc.Locations;
            var location = GetRandom(_locations, l => l.IsCountry == true);
            var query = new Query
            {
                Limit = ItemLimit
            };

            // Act
            var clanRankingList = await locations.GetRankingsClansVersusAsync(location.Id, query);

            // Assert
            Assert.IsNotNull(clanRankingList);
            Assert.AreEqual(ItemLimit, clanRankingList.Items.Length, $"Id {location.Id}");
        }

        [TestMethod]
        public async Task GetPlayerVersusRankingsForASpecificLocation()
        {
            // Arrange
            var locations = _coc.Locations;
            var location = GetRandom(_locations, l => l.IsCountry == true);
            var query = new Query
            {
                Limit = ItemLimit
            };

            // Act
            var playerVersusRankingList = await locations.GetRankingsPlayersVersusAsync(location.Id, query);

            // Assert
            Assert.IsNotNull(playerVersusRankingList);
            Assert.IsTrue(playerVersusRankingList.Items.Length <= ItemLimit, $"Id {location.Id}");
        }
    }
}
