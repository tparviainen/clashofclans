using ClashOfClans.Core;
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
        public void GetUninitializedUriThrows()
        {
            // Arrange
            var request = new AutoValidatedRequest();

            // Act
            try
            {
                var uri = request.Uri;

                // Assert
                Assert.Fail($"Uri has a value '{uri}'");
            }
            catch (InvalidOperationException ex)
            {
                Trace.WriteLine(ex);
            }
        }

        [TestMethod]
        public void SetEmptyClanTagThrows()
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
        public void SetEmptyLeagueIdentifierThrows()
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
        public void SetEmptyLocationIdentifierThrows()
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
        public void SetEmptyPlayerTagThrows()
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
        public void SetEmptyQueryThrows()
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
        public void SetTooShortNameThrowsException()
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
        public void SetThreeCharactersLongName()
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
        public void SetAfterAndBeforeForQueryClansThrows()
        {
            // Arrange
            var request = new AutoValidatedRequest();
            var query = new QueryClans
            {
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
        public void SetAfterAndBeforeForQueryThrows()
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
        public void SetQueryWithAfterSpecified()
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
        public void SetQueryWithBeforeSpecified()
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
        public void SetInvalidSeasonIdentifierThrows()
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
        public void SetNullWarTagThrows()
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
        public void SetInvalidWarTagThrows()
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
        public void EachRequestHasUniqueCorrelationId()
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
        public void SetValidLabelIds()
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
        public void SetMultipleLabelIds()
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
        public void SetMultipleLabelIdsWithInvalidSeparatorThrows()
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
