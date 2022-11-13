using ClashOfClans.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClashOfClans.Tests.Unit.AutoValidatedRequestTests
{
    [TestClass]
    public class SeasonIdTests
    {
        [TestMethod]
        public void SetAndGet()
        {
            // Arrange
            var firstSeason = "2015-07";

            // Act
            var request = new AutoValidatedRequest
            {
                SeasonId = firstSeason
            };

            // Assert
            Assert.AreEqual(firstSeason, request.SeasonId);
        }

        [TestMethod]
        public void SetInvalidSeasonIdentifierThrows()
        {
            // Arrange
            var request = new AutoValidatedRequest();

            // Act
            void SetSeasonId() => request.SeasonId = null;

            // Assert
            Assert.ThrowsException<ArgumentException>(SetSeasonId);
        }
    }
}
