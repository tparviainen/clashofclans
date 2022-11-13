using ClashOfClans.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ClashOfClans.Tests.Unit
{
    [TestClass]
    public class ThrottleRequestsPerSecondTests
    {
        [TestMethod]
        public void ThrowExceptionForInvalidThrottleLimit()
        {
            // Arrange

            // Act

            // Assert
            Assert.ThrowsException<ArgumentException>(() => new ThrottleRequestsPerSecond(0));
        }

        [TestMethod]
        public async Task ThrottleIndividualApiCalls()
        {
            // Arrange
            var maxRequestsPerSecond = 20;
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

        [TestMethod]
        public async Task ThrottleSimultaneousApiCalls()
        {
            // Arrange
            var rounds = 3;
            var maxRequestsPerSecond = 50;
            var throttleRequests = new ThrottleRequestsPerSecond(maxRequestsPerSecond);
            var tasks = new List<Task>();

            // Act
            var stopWatch = Stopwatch.StartNew();
            for (int i = 0; i < rounds * maxRequestsPerSecond; i++)
            {
                tasks.Add(throttleRequests.WaitAsync());
            }

            await Task.WhenAll(tasks);
            var elapsed = stopWatch.ElapsedMilliseconds;

            // Assert
            var delayForTwoRequests = 1000 / maxRequestsPerSecond * 2;
            Assert.IsTrue(elapsed > (rounds * 1000 - delayForTwoRequests), $"Elapsed: {elapsed}");
        }
    }
}
