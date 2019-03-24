using ClashOfClans.Core;
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
            var players = new Players(Token);

            // Act
            var player = await players.GetAsync(PlayerTag);

            // Assert
            Assert.IsNotNull(player);
        }
    }
}
