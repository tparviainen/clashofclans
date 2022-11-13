using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ClashOfClans.Tests.Integration
{
    [TestClass]
    public class DependencyInjectionTests
    {
        private static IConfigurationRoot _config = default!;
        private readonly IEnumerable<string> _tokens;

        public DependencyInjectionTests()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("AppSettings.test.json")
                .Build();

            _tokens = _config.GetSection("api:tokens").GetChildren().Select(x => x.Value);
        }

        [TestMethod]
        public void GetIClansService()
        {
            // Arrange
            var services = BuildServiceProvider();

            // Act
            using var scope = services.CreateScope();
            var clash = scope.ServiceProvider.GetRequiredService<IClashOfClans>();
            var clans = scope.ServiceProvider.GetRequiredService<IClans>();

            // Assert
            Assert.IsNotNull(clans);
            Assert.AreEqual(clans, clash.Clans);
        }

        [TestMethod]
        public void GetILocationsService()
        {
            // Arrange
            var services = BuildServiceProvider();

            // Act
            using var scope = services.CreateScope();
            var clash = scope.ServiceProvider.GetRequiredService<IClashOfClans>();
            var locations = scope.ServiceProvider.GetRequiredService<ILocations>();

            // Assert
            Assert.IsNotNull(locations);
            Assert.AreEqual(locations, clash.Locations);
        }

        [TestMethod]
        public void GetILeaguesService()
        {
            // Arrange
            var services = BuildServiceProvider();

            // Act
            using var scope = services.CreateScope();
            var clash = scope.ServiceProvider.GetRequiredService<IClashOfClans>();
            var leagues = scope.ServiceProvider.GetRequiredService<ILeagues>();

            // Assert
            Assert.IsNotNull(leagues);
            Assert.AreEqual(leagues, clash.Leagues);
        }

        [TestMethod]
        public void GetIPlayersService()
        {
            // Arrange
            var services = BuildServiceProvider();

            // Act
            using var scope = services.CreateScope();
            var clash = scope.ServiceProvider.GetRequiredService<IClashOfClans>();
            var players = scope.ServiceProvider.GetRequiredService<IPlayers>();

            // Assert
            Assert.IsNotNull(players);
            Assert.AreEqual(players, clash.Players);
        }

        [TestMethod]
        public void GetILabelsService()
        {
            // Arrange
            var services = BuildServiceProvider();

            // Act
            using var scope = services.CreateScope();
            var clash = scope.ServiceProvider.GetRequiredService<IClashOfClans>();
            var labels = scope.ServiceProvider.GetRequiredService<ILabels>();

            // Assert
            Assert.IsNotNull(labels);
            Assert.AreEqual(labels, clash.Labels);
        }

        [TestMethod]
        public void GetIGoldPassService()
        {
            // Arrange
            var services = BuildServiceProvider();

            // Act
            using var scope = services.CreateScope();
            var clash = scope.ServiceProvider.GetRequiredService<IClashOfClans>();
            var goldPass = scope.ServiceProvider.GetRequiredService<IGoldPass>();

            // Assert
            Assert.IsNotNull(goldPass);
            Assert.AreEqual(goldPass, clash.GoldPass);
        }

        private ServiceProvider BuildServiceProvider()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddClashOfClans(config =>
            {
                config.Tokens.Add(_tokens.First());
            });

            return serviceCollection.BuildServiceProvider();
        }
    }
}
