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
        public void InvalidClanTagStartCharacterThrows()
        {
            // Arrange
            var request = new AutoValidatedRequest();

            foreach (var clanTag in ClanTags)
            {
                try
                {
                    // Act
                    request.ClanTag = clanTag[1..];

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
        public void ClanTagsFromConfigFileAreValid()
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
        public void InvalidPlayerTagStartCharacterThrows()
        {
            // Arrange
            var request = new AutoValidatedRequest();

            foreach (var playerTag in PlayerTags)
            {
                try
                {
                    // Act
                    request.PlayerTag = playerTag[1..];

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
        public void PlayerTagsFromConfigFileAreValid()
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
