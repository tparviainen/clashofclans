using ClashOfClans.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClashOfClans.Tests.Unit.AutoValidatedRequestTests
{
    [TestClass]
    public class ClanTagTests
    {
        [TestMethod]
        public void SetAndGet()
        {
            // Arrange
            var clanTag = "#123456789";

            // Act
            var request = new AutoValidatedRequest
            {
                ClanTag = clanTag
            };

            // Assert
            Assert.AreEqual(clanTag, request.ClanTag);
        }

        [TestMethod]
        public void SetEmptyClanTagThrows()
        {
            // Arrange
            var request = new AutoValidatedRequest();

            // Act
            void SetClanTag() => request.ClanTag = null;

            // Assert
            Assert.ThrowsException<ArgumentException>(SetClanTag);
        }

        [TestMethod]
        public void ClanTagMustStartWithHashCharacter()
        {
            // Arrange
            var request = new AutoValidatedRequest();

            // Act
            void SetClanTag() => request.ClanTag = "123456789";

            // Assert
            Assert.ThrowsException<ArgumentException>(SetClanTag);
        }
    }
}
