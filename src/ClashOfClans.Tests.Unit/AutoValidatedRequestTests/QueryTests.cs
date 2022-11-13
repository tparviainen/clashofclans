using ClashOfClans.Core;
using ClashOfClans.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClashOfClans.Tests.Unit.AutoValidatedRequestTests
{
    [TestClass]
    public class QueryTests
    {
        [TestMethod]
        public void SetQueryWithBeforeSpecified()
        {
            // Arrange
            var before = "Before";
            var request = new AutoValidatedRequest();
            var query = new Query
            {
                Before = before
            };

            // Act
            request.Query = query;

            // Assert
            Assert.AreEqual(before, request.Query.Before);
        }

        [TestMethod]
        public void SetQueryWithAfterSpecified()
        {
            // Arrange
            var after = "After";
            var request = new AutoValidatedRequest();
            var query = new Query
            {
                After = after
            };

            // Act
            request.Query = query;

            // Assert
            Assert.AreEqual(after, request.Query.After);
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

            // Act
            void SetQuery() => request.Query = query;

            // Assert
            Assert.ThrowsException<ArgumentException>(SetQuery);
        }

        [TestMethod]
        public void SetEmptyQuerySucceeds()
        {
            // Arrange

            // Act
            var request = new AutoValidatedRequest
            {
                Query = null
            };

            // Assert
            Assert.IsNull(request.Query);
        }
    }
}
