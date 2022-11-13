using ClashOfClans.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClashOfClans.Tests.Unit.AutoValidatedRequestTests
{
    [TestClass]
    public class UriTests
    {
        [TestMethod]
        public void SetAndGet()
        {
            // Arrange
            var uri = "path-to-resource";

            // Act
            var request = new AutoValidatedRequest
            {
                Uri = $"/{uri}"
            };

            // Assert
            Assert.AreEqual(uri, request.Uri);
        }

        [TestMethod]
        public void GetUninitializedUriThrows()
        {
            // Arrange
            var request = new AutoValidatedRequest();

            // Act
            string GetUri() => request.Uri;

            // Assert
            Assert.ThrowsException<InvalidOperationException>(GetUri);
        }

        [TestMethod]
        public void WrongStartCharacterThrows()
        {
            // Arrange
            var request = new AutoValidatedRequest();

            // Act
            void SetUri() => request.Uri = "path-to-resource";

            // Assert
            Assert.ThrowsException<ArgumentException>(SetUri);
        }
    }
}
