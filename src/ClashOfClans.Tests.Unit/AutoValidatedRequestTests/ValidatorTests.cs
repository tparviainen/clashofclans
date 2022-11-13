using ClashOfClans.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClashOfClans.Tests.Unit.AutoValidatedRequestTests
{
    [TestClass]
    public class ValidatorTests
    {
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
    }
}
