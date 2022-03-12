using ClashOfClans.Core;
using ClashOfClans.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

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
        public void SerializeAndDeserializeClashOfClansExceptionUsingNewtonsoft()
        {
            // Arrange
            var error = new ClientError
            {
                Message = "message",
                Reason = "reason"
            };
            var originalException = new ClashOfClansException(error);

            // Act
            var output = JsonConvert.SerializeObject(originalException);
            var deserializedException = JsonConvert.DeserializeObject<ClashOfClansException>(output);

            // Assert
            Assert.IsNotNull(deserializedException);
            Assert.AreEqual(originalException.Message, deserializedException.Message);
            Assert.AreEqual(originalException.Error.Message, deserializedException.Error.Message);
            Assert.AreEqual(originalException.Error.Reason, deserializedException.Error.Reason);
        }
    }
}
