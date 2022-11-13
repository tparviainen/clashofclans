using ClashOfClans.Core;
using ClashOfClans.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClashOfClans.Tests.Unit.AutoValidatedRequestTests
{
    [TestClass]
    public class QueryClansTests
    {
        [TestMethod]
        public void SetEmptyQueryThrows()
        {
            // Arrange
            var request = new AutoValidatedRequest();

            // Act
            void SetQueryClans() => request.QueryClans = null;

            // Assert
            Assert.ThrowsException<ArgumentException>(SetQueryClans);
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

            // Act
            void SetQueryClans() => request.QueryClans = query;

            // Assert
            Assert.ThrowsException<ArgumentException>(SetQueryClans);
        }

        [TestMethod]
        public void SetThreeCharactersLongName()
        {
            // Arrange
            var name = "abc";
            var request = new AutoValidatedRequest();
            var query = new QueryClans
            {
                Name = name
            };

            // Act
            request.QueryClans = query;

            // Assert
            Assert.AreEqual(name, request.QueryClans.Name);
        }

        [TestMethod]
        public void SetValidLabelIds()
        {
            // Arrange
            var labelIds = "56000000";
            var request = new AutoValidatedRequest();
            var query = new QueryClans
            {
                LabelIds = labelIds
            };

            // Act
            request.QueryClans = query;

            // Assert
            Assert.AreEqual(labelIds, request.QueryClans.LabelIds);
        }

        [TestMethod]
        public void SetMultipleLabelIds()
        {
            // Arrange
            var labelIds = "56000000,56000001,56000002";
            var request = new AutoValidatedRequest();
            var query = new QueryClans
            {
                LabelIds = labelIds
            };

            // Act
            request.QueryClans = query;

            // Assert
            Assert.AreEqual(labelIds, request.QueryClans.LabelIds);
        }

        [TestMethod]
        public void SetMultipleLabelIdsWithInvalidSeparatorThrows()
        {
            // Arrange
            var labelIds = "56000000, 56000001, 56000002";
            var request = new AutoValidatedRequest();
            var query = new QueryClans
            {
                LabelIds = labelIds
            };

            // Act
            void SetLabelIds() => request.QueryClans = query;

            // Assert
            Assert.ThrowsException<ArgumentException>(SetLabelIds);
        }
    }
}
