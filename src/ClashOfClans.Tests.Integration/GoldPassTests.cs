using ClashOfClans.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ClashOfClans.Tests.Integration
{
    [TestClass]
    public class GoldPassTests : TestsBase
    {
        [TestMethod]
        public async Task GetCurrentGoldPassSeason()
        {
            try
            {
                // Arrange

                // Act
                var goldPassSeason = await _coc.GoldPass.GetCurrentGoldPassSeasonAsync();

                // Assert
                Assert.IsNotNull(goldPassSeason);
            }
            catch (ClashOfClansException ex)
            {
                Trace.WriteLine($"ClashOfClansException reason: {ex.Error.Reason}, message: {ex.Error.Message}");
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                Assert.Fail();
            }
        }
    }
}
