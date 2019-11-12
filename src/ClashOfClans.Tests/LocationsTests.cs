using ClashOfClans.Models;
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
            var locationList = (LocationList)await locations.GetLocationsAsync();

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
            var locationId = GetRandom(_locations).Id;

            // Act
            var location = await _coc.Locations.GetLocationAsync(locationId);

            // Assert
            Assert.IsNotNull(location);
        }

        [TestMethod]
        public async Task GetClanRankingsForASpecificLocation()
        {
            // Arrange
            var location = GetRandom(_locations, l => l.IsCountry == true);
            var query = new Query
            {
                Limit = ItemLimit
            };

            // Act
            var clanRankingList = (ClanRankingList)await _coc.Locations.GetClanRankingAsync(location.Id, query);

            // Assert
            Assert.IsNotNull(clanRankingList);
            Assert.AreEqual(ItemLimit, clanRankingList.Count, $"Id {location.Id}");
        }

        [TestMethod]
        public async Task GetPlayerRankingsForASpecificLocation()
        {
            // Arrange
            var location = GetRandom(_locations, l => l.IsCountry == true);
            var query = new Query
            {
                Limit = ItemLimit
            };

            // Act
            var playerRankingList = (PlayerRankingList)await _coc.Locations.GetPlayerRankingAsync(location.Id, query);

            // Assert
            Assert.IsNotNull(playerRankingList);
            Assert.IsTrue(playerRankingList.Count <= ItemLimit, $"Id {location.Id}");
        }

        [TestMethod]
        public async Task GetClanVersusRankingsForASpecificLocation()
        {
            // Arrange
            var location = GetRandom(_locations, l => l.IsCountry == true);
            var query = new Query
            {
                Limit = ItemLimit
            };

            // Act
            var clanRankingList = (ClanVersusRankingList)await _coc.Locations.GetClanVersusRankingAsync(location.Id, query);

            // Assert
            Assert.IsNotNull(clanRankingList);
            Assert.AreEqual(ItemLimit, clanRankingList.Count, $"Id {location.Id}");
        }

        [TestMethod]
        public async Task GetPlayerVersusRankingsForASpecificLocation()
        {
            // Arrange
            var location = GetRandom(_locations, l => l.IsCountry == true);
            var query = new Query
            {
                Limit = ItemLimit
            };

            // Act
            var playerVersusRankingList = (PlayerVersusRankingList)await _coc.Locations.GetPlayerVersusRankingAsync(location.Id, query);

            // Assert
            Assert.IsNotNull(playerVersusRankingList);
            Assert.IsTrue(playerVersusRankingList.Count <= ItemLimit, $"Id {location.Id}");
        }
    }
}
