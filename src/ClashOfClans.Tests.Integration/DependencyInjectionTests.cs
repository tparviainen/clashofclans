using ClashOfClans.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClashOfClans.Tests.Integration
{
    [TestClass]
    public class DependencyInjectionTests
    {
        protected static IConfigurationRoot _config = default!;
        private readonly IEnumerable<string> _tokens;

        public DependencyInjectionTests()
        {
            _config = new ConfigurationBuilder()
                            .AddJsonFile("AppSettings.test.json")
                            .Build();

            _tokens = _config.GetSection("api:tokens").GetChildren().Select(x => x.Value);
        }

        [TestMethod]
        public async Task GetCurrentGoldPassSeasonViaRootDI()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddClashOfClans(config =>
            {
                config.Tokens.AddRange(_tokens);
            });

            var services = serviceCollection.BuildServiceProvider();

            // Act
            try
            {
                using var scope = services.CreateScope();
                var clash = services.GetRequiredService<IClashOfClans>();
                var goldPassSeason = await clash.GoldPass.GetCurrentGoldPassSeasonAsync();

                // Assert
                Assert.IsNotNull(goldPassSeason);
            }
            catch (ClashOfClansException ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod]
        public async Task GetLocationsViaChildDI()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddClashOfClans(config =>
            {
                config.Tokens.AddRange(_tokens);
            });

            var services = serviceCollection.BuildServiceProvider();

            // Act
            try
            {
                using var scope = services.CreateScope();
                var locations = services.GetRequiredService<ILocations>();
                var locationList = await locations.GetLocationsAsync();

                // Assert
                Assert.IsNotNull(locationList);
            }
            catch (ClashOfClansException ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
    }
}
