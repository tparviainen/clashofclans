using ClashOfClans.Models;
using ClashOfClans.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ClashOfClans.Tests.Unit
{
    [TestClass]
    public class QueryTests
    {
        [TestMethod]
        public void EmptyQueryShouldReturnEmptyString()
        {
            // Arrange
            var query = new Query();

            // Act
            var queryString = query.ToString();

            // Assert
            Assert.AreEqual(string.Empty, queryString);
        }

        [TestMethod]
        public void MoveToPreviousOrNextItemsIsNotPossibleWithEmptyMarkers()
        {
            // Arrange
            var query = new Query
            {
            };

            // Act
            var prev = query.MoveToPreviousItems();
            var next = query.MoveToNextItems();

            // Assert
            Assert.IsFalse(prev, "Empty markers should not allow move!");
            Assert.IsFalse(next, "Empty markers should not allow move!");
        }

        [TestMethod]
        public void QueryWithLimitSet()
        {
            // Arrange
            var query = new Query
            {
                Limit = 10
            };

            // Act
            var queryString = query.ToString();

            // Assert
            Assert.AreEqual("?limit=10", queryString);
        }

        [TestMethod]
        public void QueryWithLimitAndAfterSet()
        {
            // Arrange
            var query = new Query
            {
                Limit = 20,
                After = "12345"
            };

            // Act
            var queryString = query.ToString();

            // Assert
            Assert.AreEqual('?', queryString[0]);
            Assert.IsTrue(queryString.Contains("limit=20"));
            Assert.IsTrue(queryString.Contains("after=12345"));
            Assert.AreEqual(1, queryString.Count(c => c == '&'), $"The amount of '&' characters in '{queryString}' is wrong.");
        }

        [TestMethod]
        public void QueryClansWithLocationIdSet()
        {
            // Arrange
            var query = new QueryClans
            {
                LocationId = 42
            };

            // Act
            var queryString = query.ToString();

            // Assert
            Assert.AreEqual("?locationid=42", queryString);
        }

        [TestMethod]
        public void QueryClansWithLocationIdAndLimitSet()
        {
            // Arrange
            var query = new QueryClans
            {
                LocationId = 42,
                Limit = 10
            };

            // Act
            var queryString = query.ToString();

            // Assert
            Assert.AreEqual('?', queryString[0]);
            Assert.IsTrue(queryString.Contains('&'));
            Assert.IsTrue(queryString.Contains("locationid=42"));
            Assert.IsTrue(queryString.Contains("limit=10"));
        }

        [TestMethod]
        public void QueryClansWithWarFrequencySet()
        {
            // Arrange
            var query = new QueryClans
            {
                WarFrequency = WarFrequency.LessThanOncePerWeek
            };

            // Act
            var queryString = query.ToString();

            // Assert
            Assert.AreEqual("?warfrequency=lessThanOncePerWeek", queryString);
        }
    }
}
