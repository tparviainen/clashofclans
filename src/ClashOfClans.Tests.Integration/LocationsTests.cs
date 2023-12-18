using ClashOfClans.Models;
using ClashOfClans.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace ClashOfClans.Tests.Integration
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
        [DataRow("Russia")]
        [DataRow("Finland")]
        [DataRow("United States")]
        public void GetLocationInformationByName(string locationName)
        {
            // Arrange

            // Act
            var location = _locations[locationName];

            // Assert
            Assert.IsNotNull(location, $"Valid location '{locationName}' should return location information.");
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("Funland")]
        [DataRow("Republic of Finland")]
        public void InvalidLocationNameReturnsNull(string locationName)
        {
            // Arrange

            // Act
            var location = _locations[locationName];

            // Assert
            Assert.IsNull(location, $"Invalid location '{locationName}' should return null.");
        }

        [TestMethod]
        [DataRow("Canada")]
        [DataRow("Finland")]
        public void ValidLocationNameWithWrongCaseSensitivityReturnsNull(string locationName)
        {
            // Arrange
            var validLocation = _locations[locationName]!;
            var invalidLocationName = validLocation.Name.ToLower();

            // Act
            var invalidLocation = _locations[invalidLocationName];

            // Assert
            Assert.IsNull(invalidLocation, $"Location '{invalidLocationName}' should return null.");
            Assert.AreNotEqual(validLocation, invalidLocation);
        }

        [TestMethod]
        public async Task GetLocationInformationById()
        {
            // Arrange
            var locationId = GetRandom(_locations).Id;

            // Act
            var location = await _coc.Locations.GetLocationAsync(locationId);

            // Assert
            Assert.IsNotNull(location, $"Valid location id '{locationId}' should return location information.");
        }

        [TestMethod]
        public async Task GetClanRankingsForASpecificLocation()
        {
            // Arrange
            var location = GetRandom(_locations, l => l.IsCountry);
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
            var location = GetRandom(_locations, l => l.IsCountry);
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
        public async Task GetCapitalRankingsForASpecificLocation()
        {
            // Arrange
            var location = GetRandom(_locations, l => l.IsCountry);
            var query = new Query
            {
                Limit = ItemLimit
            };

            // Act
            var clanCapitalRankingList = (ClanCapitalRankingList)await _coc.Locations.GetClanCapitalRankingAsync(location.Id, query);

            // Assert
            Assert.IsNotNull(clanCapitalRankingList);
            Assert.IsTrue(clanCapitalRankingList.Count <= ItemLimit, $"Id {location.Id}");
        }

        [TestMethod]
        public async Task GetPlayerBuilderBaseRankingsForASpecificLocation()
        {
            // Arrange
            var location = GetRandom(_locations, l => l.IsCountry);
            var query = new Query
            {
                Limit = ItemLimit
            };

            // Act
            var playerBuilderBaseRankingList = (PlayerBuilderBaseRankingList)await _coc.Locations.GetPlayerBuilderBaseRankingAsync(location.Id, query);

            // Assert
            Assert.IsNotNull(playerBuilderBaseRankingList);
            Assert.IsTrue(playerBuilderBaseRankingList.Count <= ItemLimit, $"Id {location.Id}");
        }

        [TestMethod]
        public async Task GetClanBuilderBaseRankingsForASpecificLocation()
        {
            // Arrange
            var location = GetRandom(_locations, l => l.IsCountry);
            var query = new Query
            {
                Limit = ItemLimit
            };

            // Act
            var clanBuilderBaseRankingList = (ClanBuilderBaseRankingList)await _coc.Locations.GetClanBuilderBaseRankingAsync(location.Id, query);

            // Assert
            Assert.IsNotNull(clanBuilderBaseRankingList);
            Assert.IsTrue(clanBuilderBaseRankingList.Count <= ItemLimit, $"Id {location.Id}");
        }
    }
}
