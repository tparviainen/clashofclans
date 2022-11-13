using ClashOfClans.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClashOfClans.Tests.Unit.AutoValidatedRequestTests
{
    [TestClass]
    public class PlayerTagTests
    {
        [TestMethod]
        public void SetAndGet()
        {
            // Arrange
            var playerTag = "#123456789";

            // Act
            var request = new AutoValidatedRequest
            {
                PlayerTag = playerTag
            };

            // Assert
            Assert.AreEqual(playerTag, request.PlayerTag);
        }

        [TestMethod]
        public void SetEmptyPlayerTagThrows()
        {
            // Arrange
            var request = new AutoValidatedRequest();

            // Act
            void SetPlayerTag() => request.PlayerTag = "";

            // Assert
            Assert.ThrowsException<ArgumentException>(SetPlayerTag);
        }

        [TestMethod]
        public void PlayerTagMustStartWithHashCharacter()
        {
            // Arrange
            var request = new AutoValidatedRequest();

            // Act
            void SetPlayerTag() => request.PlayerTag = "123456789";

            // Assert
            Assert.ThrowsException<ArgumentException>(SetPlayerTag);
        }
    }
}
