using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
            var notExpected = DateTime.MinValue;

            // Act
            var goldPassSeason = await _coc.GoldPass.GetCurrentGoldPassSeasonAsync();

            // Assert
            Assert.IsNotNull(goldPassSeason);
            Assert.AreNotEqual(notExpected, goldPassSeason.StartTime);
            Assert.AreNotEqual(notExpected, goldPassSeason.EndTime);
        }
    }
}
