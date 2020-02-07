using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ClashOfClans.Tests.Integration
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
                var player = await _coc.Players.GetPlayerAsync(playerTag);

                // Assert
                Assert.IsNotNull(player);
            }
        }

        [TestMethod]
        public async Task GetPlayerInformationInALoopWithoutThrottling()
        {
            // Arrange
            var tokenCount = 0;
            var playerTag = PlayerTags.First();
            var requestCount = 200;
            var requestsPerSecond = 50;
            var sw = new Stopwatch();
            _coc.Configure(options =>
            {
                tokenCount = options.Tokens.Count;
                Assert.IsTrue(options.MaxRequestsPerSecond == requestsPerSecond);
            });

            // Act
            try
            {
                sw.Start();
                var results = Enumerable.Range(1, requestCount).Select(i => _coc.Players.GetPlayerAsync(playerTag));
                _ = await Task.WhenAll(results);
                sw.Stop();

                Trace.WriteLine($"{requestCount} requests took {sw.ElapsedMilliseconds} ms with {tokenCount} token(s) and {requestsPerSecond} requests/second rate");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail(ex.ToString());
            }
        }
    }
}
