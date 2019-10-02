using ClashOfClans.Search;
using ClashOfClans.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace ClashOfClans.Tests
{
    [TestClass]
    public class ValidatorTests : TestsBase
    {
        [TestMethod]
        public void ClanTagMustNotBeEmpty()
        {
            // Arrange
            var validator = new Validator();

            try
            {
                // Act
                validator.ValidateClanTag(null);

                // Assert
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Trace.WriteLine(ex);
            }
        }

        [TestMethod]
        public void ClanTagsStartWithHashCharacter()
        {
            // Arrange
            var validator = new Validator();

            foreach (var clanTag in ClanTags)
            {
                try
                {
                    // Act
                    validator.ValidateClanTag(clanTag.Substring(1));

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
        public void LeagueIdentifierMustNotBeEmpty()
        {
            // Arrange
            var validator = new Validator();

            try
            {
                // Act
                validator.ValidateLeagueId(null);

                // Assert
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Trace.WriteLine(ex);
            }
        }

        [TestMethod]
        public void LocationIdentifierMustNotNeEmpty()
        {
            // Arrange
            var validator = new Validator();

            try
            {
                // Act
                validator.ValidateLocationId(null);

                // Assert
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Trace.WriteLine(ex);
            }
        }

        [TestMethod]
        public void PlayerTagMustNotBeEmpty()
        {
            // Arrange
            var validator = new Validator();

            try
            {
                // Act
                validator.ValidatePlayerTag("");

                // Assert
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Trace.WriteLine(ex);
            }
        }

        [TestMethod]
        public void PlayerTagsStartWithHashCharacter()
        {
            // Arrange
            var validator = new Validator();

            foreach (var playerTag in PlayerTags)
            {
                try
                {
                    // Act
                    validator.ValidatePlayerTag(playerTag.Substring(1));

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
        public void QueryMustNotBeEmpty()
        {
            // Arrange
            var validator = new Validator();

            try
            {
                // Act
                validator.ValidateQueryClans(null);

                // Assert
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Trace.WriteLine(ex);
            }
        }

        [TestMethod]
        public void NameNeedsToBeAtLeastThreeCharactersLong()
        {
            // Arrange
            var validator = new Validator();
            var query = new QueryClans
            {
                Name = "ab"
            };

            try
            {
                // Act
                validator.ValidateQueryClans(query);

                // Assert
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Trace.WriteLine(ex);
            }
        }

        [TestMethod]
        public void ThreeCharactersLongNameIsValid()
        {
            // Arrange
            var validator = new Validator();
            var query = new QueryClans
            {
                Name = "abc"
            };

            try
            {
                // Act
                validator.ValidateQueryClans(query);
            }
            catch (Exception)
            {
                // Assert
                Assert.Fail();
            }
        }

        [TestMethod]
        public void OnlyAfterOrBeforeCanBeSpecifiedForAQueryNotBoth()
        {
            // Arrange
            var validator = new Validator();
            var query = new Query
            {
                After = "after",
                Before = "before"
            };

            try
            {
                // Act
                validator.ValidateQuery(query);

                // Assert
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Trace.WriteLine(ex);
            }
        }

        [TestMethod]
        public void QueryWithAfterSpecifiedSucceeds()
        {
            // Arrange
            var validator = new Validator();
            var query = new Query
            {
                After = "after"
            };

            try
            {
                // Act
                validator.ValidateQuery(query);
            }
            catch (Exception)
            {
                // Assert
                Assert.Fail();
            }
        }

        [TestMethod]
        public void QueryWithBeforeSpecifiedSucceeds()
        {
            // Arrange
            var validator = new Validator();
            var query = new Query
            {
                Before = "Before"
            };

            try
            {
                // Act
                validator.ValidateQuery(query);
            }
            catch (Exception)
            {
                // Assert
                Assert.Fail();
            }
        }

        [TestMethod]
        public void SeasonIdentifierMustNotBeEmpty()
        {
            // Arrange
            var validator = new Validator();

            try
            {
                // Act
                validator.ValidateSeasonId(null);

                // Assert
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Trace.WriteLine(ex);
            }
        }

        [TestMethod]
        public void TokenMustNotBeEmpty()
        {
            // Arrange
            var validator = new Validator();

            try
            {
                // Act
                validator.ValidateToken(null);

                // Assert
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Trace.WriteLine(ex);
            }
        }

        [TestMethod]
        public void WarTagMustNotBeEmpty()
        {
            // Arrange
            var validator = new Validator();

            try
            {
                // Act
                validator.ValidateWarTag(null);

                // Assert
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Trace.WriteLine(ex);
            }
        }

        [TestMethod]
        public void WarTagIsNotValid()
        {
            // Arrange
            var validator = new Validator();

            try
            {
                // Act
                validator.ValidateWarTag(Constants.InvalidWarTag);

                // Assert
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Trace.WriteLine(ex);
            }
        }
    }
}
