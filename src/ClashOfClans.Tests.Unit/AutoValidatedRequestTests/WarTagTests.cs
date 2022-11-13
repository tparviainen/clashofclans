using ClashOfClans.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClashOfClans.Tests.Unit.AutoValidatedRequestTests
{
    [TestClass]
    public class WarTagTests
    {
        [TestMethod]
        public void SetAndGet()
        {
            // Arrange
            var warTag = "#123456789";

            // Act
            var request = new AutoValidatedRequest
            {
                WarTag = warTag
            };

            // Assert
            Assert.AreEqual(warTag, request.WarTag);
        }

        [TestMethod]
        public void SetNullWarTagThrows()
        {
            // Arrange
            var request = new AutoValidatedRequest();

            // Act
            void SetWarTag() => request.WarTag = null;

            // Assert
            Assert.ThrowsException<ArgumentException>(SetWarTag);
        }

        [TestMethod]
        public void SetInvalidWarTagThrows()
        {
            // Arrange
            var request = new AutoValidatedRequest();

            // Act
            void SetWarTag() => request.WarTag = Constants.InvalidWarTag;

            // Assert
            Assert.ThrowsException<ArgumentException>(SetWarTag);
        }
    }
}
