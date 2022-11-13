using ClashOfClans.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClashOfClans.Tests.Unit.AutoValidatedRequestTests
{
    [TestClass]
    public class LocationIdTests
    {
        [TestMethod]
        public void SetAndGet()
        {
            // Arrange
            var finland = 32000086;

            // Act
            var request = new AutoValidatedRequest
            {
                LocationId = finland
            };

            // Assert
            Assert.AreEqual(finland, request.LocationId);
        }

        [TestMethod]
        public void SetEmptyLocationIdentifierThrows()
        {
            // Arrange
            var request = new AutoValidatedRequest();

            // Act
            void SetLocationId() => request.LocationId = null;

            // Assert
            Assert.ThrowsException<ArgumentException>(SetLocationId);
        }
    }
}
