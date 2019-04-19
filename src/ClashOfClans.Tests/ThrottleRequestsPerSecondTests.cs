using ClashOfClans.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ClashOfClans.Tests
{
    [TestClass]
    public class ThrottleRequestsPerSecondTests
    {
        [TestMethod]
        public async Task EnsureRequestsAreThrottled()
        {
            // Arrange
            var maxRequestsPerSecond = 10;
            var throttleRequests = new ThrottleRequestsPerSecond(maxRequestsPerSecond);
            var totalTime = new TimeSpan(0, 0, 1);
            var loopCount = 0;

            // Act
            var stopWatch = Stopwatch.StartNew();

            while (true)
            {
                await throttleRequests.WaitAsync();

                if (stopWatch.Elapsed >= totalTime)
                {
                    stopWatch.Stop();
                    break;
                }

                loopCount++;
            }

            // Assert
            Assert.IsTrue(loopCount <= maxRequestsPerSecond, $"Loopcount: {loopCount}");
        }
    }
}
