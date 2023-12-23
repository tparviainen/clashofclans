using ClashOfClans.Core;
using ClashOfClans.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClashOfClans.Tests.Unit
{
    [TestClass]
    public class ClashOfClansExceptionTests
    {
        [TestMethod]
        [ExpectedException(typeof(ClashOfClansException))]
        public void ThrowClashOfClansException()
        {
            // Arrange
            var error = new ClientError();

            // Act
            throw new ClashOfClansException(error);

            // Assert
        }

        [TestMethod]
        public void ClashOfClansExceptionHasClientError()
        {
            // Arrange
            var error = new ClientError
            {
                Reason = "Error reason",
                Message = "Error message"
            };

            try
            {
                // Act
                throw new ClashOfClansException(error);
            }
            catch (ClashOfClansException ex)
            {
                // Assert
                Assert.AreEqual(error.Reason, ex.Error.Reason);
                Assert.AreEqual(error.Message, ex.Error.Message);
            }
        }
    }
}
