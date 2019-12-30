using ClashOfClans.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace ClashOfClans.Tests.Integration
{
    [TestClass]
    public class ValidatorTests : TestsBase
    {
        [TestMethod]
        public void ClanTagsDontStartWithHashCharacter()
        {
            // Arrange
            var request = new AutoValidatedRequest();

            foreach (var clanTag in ClanTags)
            {
                try
                {
                    // Act
                    request.ClanTag = clanTag.Substring(1);

                    // Assert
                    Assert.Fail();
                }
                catch (ArgumentException ex)
                {
                    Trace.WriteLine(ex);
                }
            }
        }

        [TestMethod]
        public void ClanTagsStartWithHashCharacter()
        {
            // Arrange
            var request = new AutoValidatedRequest();

            foreach (var clanTag in ClanTags)
            {
                try
                {
                    // Act
                    request.ClanTag = clanTag;
                }
                catch (ArgumentException ex)
                {
                    // Assert
                    Assert.Fail();

                    Trace.WriteLine(ex);
                }
            }
        }

        [TestMethod]
        public void PlayerTagsDontStartWithHashCharacter()
        {
            // Arrange
            var request = new AutoValidatedRequest();

            foreach (var playerTag in PlayerTags)
            {
                try
                {
                    // Act
                    request.PlayerTag = playerTag.Substring(1);

                    // Assert
                    Assert.Fail();
                }
                catch (ArgumentException ex)
                {
                    Trace.WriteLine(ex);
                }
            }
        }

        [TestMethod]
        public void PlayerTagsStartWithHashCharacter()
        {
            // Arrange
            var request = new AutoValidatedRequest();

            foreach (var playerTag in PlayerTags)
            {
                try
                {
                    // Act
                    request.PlayerTag = playerTag;
                }
                catch (ArgumentException ex)
                {
                    // Assert
                    Assert.Fail();

                    Trace.WriteLine(ex);
                }
            }
        }
    }
}
