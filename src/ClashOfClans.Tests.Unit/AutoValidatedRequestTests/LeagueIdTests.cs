using ClashOfClans.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClashOfClans.Tests.Unit.AutoValidatedRequestTests
{
    [TestClass]
    public class LeagueIdTests
    {
        [TestMethod]
        public void SetAndGet()
        {
            // Arrange
            var legendLeague = 29000022;

            // Act
            var request = new AutoValidatedRequest
            {
                LeagueId = legendLeague
            };

            // Assert
            Assert.AreEqual(legendLeague, request.LeagueId);
        }

        [TestMethod]
        public void SetEmptyLeagueIdentifierThrows()
        {
            // Arrange
            var request = new AutoValidatedRequest();

            // Act
            void SetLeagueId() => request.LeagueId = null;

            // Assert
            Assert.ThrowsException<ArgumentException>(SetLeagueId);
        }
    }
}
