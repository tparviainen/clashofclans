using ClashOfClans.Core;
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
            var query = new Query();

            // Act
            query.Limit = 10;

            // Assert
            Assert.IsTrue(query.ToString().Contains("limit=10"));
        }

        [TestMethod]
        public void QueryLimitAndAfterSet()
        {
            // Arrange
            var query = new Query();

            // Act
            query.Limit = 20;
            query.After = "12345";

            // Assert
            Assert.IsTrue(query.ToString().Contains("limit=20"));
            Assert.IsTrue(query.ToString().Contains("after=12345"));
        }
    }
}
