using ClashOfClans.Models;
using ClashOfClans.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClashOfClans.Tests
{
    [TestClass]
    public class QueryTests
    {
        [TestMethod]
        public void QueryLimitSetTo10()
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
        public void QueryLimitAndAfterSet()
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
            Assert.IsTrue(queryString.Contains("&"));
            Assert.IsTrue(queryString.Contains("limit=20"));
            Assert.IsTrue(queryString.Contains("after=12345"));
        }

        [TestMethod]
        public void QuaryClansForSpecificLocation()
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
        public void QueryClansForSpecificLocationAndLimit()
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
            Assert.IsTrue(queryString.Contains("&"));
            Assert.IsTrue(queryString.Contains("locationid=42"));
            Assert.IsTrue(queryString.Contains("limit=10"));
        }

        [TestMethod]
        public void QueryClansWithWarFrequency()
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
