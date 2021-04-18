using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace ClashOfClans.Tests.Integration
{
    [TestClass]
    public class GoldPassTests : TestsBase
    {
        [TestMethod]
        public async Task GetCurrentGoldPassSeason()
        {
            // Arrange

            // Act
            var goldPassSeason = await _coc.GoldPass.GetCurrentGoldPassSeasonAsync();

            // Assert
            Assert.IsNotNull(goldPassSeason);
        }
    }
}
