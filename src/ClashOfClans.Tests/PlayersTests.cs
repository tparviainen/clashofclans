using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace ClashOfClans.Tests
{
    [TestClass]
    public class PlayersTests : TestsBase
    {
        [TestMethod]
        public async Task GetPlayerInformation()
        {
            // Arrange

            // Act
            foreach (var playerTag in PlayerTags)
            {
                var player = await _coc.Players.GetAsync(playerTag);

                // Assert
                Assert.IsNotNull(player);
            }
        }
    }
}
