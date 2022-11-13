using ClashOfClans.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ClashOfClans.Tests.Unit
{
    [TestClass]
    public class TokenValidatorTests
    {
        [TestMethod]
        public void EmptyTokenListThrows()
        {
            // Arrange
            var tokens = new List<string>();

            // Act
            void ValidateTokens() => TokenValidator.Validate(tokens);

            // Assert
            Assert.ThrowsException<ArgumentException>(ValidateTokens);
        }

        [TestMethod]
        public void EmptyTokenInListThrows()
        {
            // Arrange
            var tokens = new List<string>
            {
                "token1",
                "",
                "token2"
            };

            // Act
            void ValidateTokens() => TokenValidator.Validate(tokens);

            // Assert
            Assert.ThrowsException<ArgumentException>(ValidateTokens);
        }

        [TestMethod]
        public void ValidTokensPassValidation()
        {
            // Arrange
            var tokens = new List<string>
            {
                "token1",
                "token2",
                "token3"
            };

            // Act
            try
            {
                TokenValidator.Validate(tokens);
            }
            catch (Exception)
            {
                // Assert
                Assert.Fail("No exception expected!");
            }
        }
    }
}
