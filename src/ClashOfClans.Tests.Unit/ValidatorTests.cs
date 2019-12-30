﻿using ClashOfClans.Core;
using ClashOfClans.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace ClashOfClans.Tests.Unit
{
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        public void ClanTagMustNotBeEmpty()
        {
            // Arrange
            var request = new AutoValidatedRequest();

            try
            {
                // Act
                request.ClanTag = null;

                // Assert
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Trace.WriteLine(ex);
            }
        }

        [TestMethod]
        public void LeagueIdentifierMustNotBeEmpty()
        {
            // Arrange
            var request = new AutoValidatedRequest();

            try
            {
                // Act
                request.LeagueId = null;

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
            var request = new AutoValidatedRequest();

            try
            {
                // Act
                request.LocationId = null;

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
            var request = new AutoValidatedRequest();

            try
            {
                // Act
                request.PlayerTag = "";

                // Assert
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Trace.WriteLine(ex);
            }
        }

        [TestMethod]
        public void QueryMustNotBeEmpty()
        {
            // Arrange
            var request = new AutoValidatedRequest();

            try
            {
                // Act
                request.QueryClans = null;

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
            var request = new AutoValidatedRequest();
            var query = new QueryClans
            {
                Name = "ab"
            };

            try
            {
                // Act
                request.QueryClans = query;

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
            var request = new AutoValidatedRequest();
            var query = new QueryClans
            {
                Name = "abc"
            };

            try
            {
                // Act
                request.QueryClans = query;
            }
            catch (Exception)
            {
                // Assert
                Assert.Fail();
            }
        }

        [TestMethod]
        public void ValidNameButInvalidPagingCombination()
        {
            // Arrange
            var request = new AutoValidatedRequest();
            var query = new QueryClans
            {
                Name = "Clan #1",
                After = "after",
                Before = "before"
            };

            try
            {
                request.QueryClans = query;

                // Assert
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Trace.WriteLine(ex);
            }
        }

        [TestMethod]
        public void OnlyAfterOrBeforeCanBeSpecifiedForAQueryNotBoth()
        {
            // Arrange
            var request = new AutoValidatedRequest();
            var query = new Query
            {
                After = "after",
                Before = "before"
            };

            try
            {
                // Act
                request.Query = query;

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
            var request = new AutoValidatedRequest();
            var query = new Query
            {
                After = "after"
            };

            try
            {
                // Act
                request.Query = query;
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
            var request = new AutoValidatedRequest();
            var query = new Query
            {
                Before = "Before"
            };

            try
            {
                // Act
                request.Query = query;
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
            var request = new AutoValidatedRequest();

            try
            {
                // Act
                request.SeasonId = null;

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
            var request = new AutoValidatedRequest();

            try
            {
                // Act
                request.WarTag = null;

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
            var request = new AutoValidatedRequest();

            try
            {
                // Act
                request.WarTag = Constants.InvalidWarTag;

                // Assert
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Trace.WriteLine(ex);
            }
        }

        [TestMethod]
        public void RequestsHaveUniqueCorrelationId()
        {
            // Arrange
            var req1 = new AutoValidatedRequest();
            var req2 = new AutoValidatedRequest();

            // Act

            // Assert
            Assert.IsNotNull(req1.CorrelationId);
            Assert.IsNotNull(req2.CorrelationId);
            Assert.AreNotEqual(req1.CorrelationId, req2.CorrelationId);
        }

        [TestMethod]
        public void ValidLabelIdsAccepted()
        {
            // Arrange
            var request = new AutoValidatedRequest();
            var query = new QueryClans
            {
                LabelIds = "56000000"
            };

            try
            {
                // Act
                request.QueryClans = query;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);

                // Assert
                Assert.Fail();
            }
        }

        [TestMethod]
        public void CommaSeparatedListOfValidLabelIdsAccepted()
        {
            // Arrange
            var request = new AutoValidatedRequest();
            var query = new QueryClans
            {
                LabelIds = "56000000,56000001,56000002"
            };

            try
            {
                // Act
                request.QueryClans = query;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);

                // Assert
                Assert.Fail();
            }
        }

        [TestMethod]
        public void ExtraSpacesBetweenCommaSeparatedListOfValidLabelIdsThrowsException()
        {
            // Arrange
            var request = new AutoValidatedRequest();
            var query = new QueryClans
            {
                LabelIds = "56000000, 56000001, 56000002"
            };

            try
            {
                // Act
                request.QueryClans = query;

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