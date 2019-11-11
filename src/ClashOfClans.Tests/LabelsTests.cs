using ClashOfClans.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace ClashOfClans.Tests
{
    [TestClass]
    public class LabelsTests : TestsBase
    {
        [TestMethod]
        public async Task ListClanLabels()
        {
            // Arrange

            // Act
            var labels = await _coc.Labels.GetClanLabelsAsync();

            // Assert
            Assert.IsNotNull(labels.Items);
        }

        [TestMethod]
        public async Task ListClanLabelsLimit5()
        {
            // Arrange
            var limit = 5;
            var query = new Query
            {
                Limit = limit
            };

            // Act
            var labels = await _coc.Labels.GetClanLabelsAsync(query);

            // Assert
            Assert.IsNotNull(labels.Items);
            Assert.AreEqual(limit, labels.Items.Count);
        }

        [TestMethod]
        public async Task ListPlayerLabels()
        {
            // Arrange

            // Act
            var labels = await _coc.Labels.GetPlayerLabelsAsync();

            // Assert
            Assert.IsNotNull(labels.Items);
        }

        [TestMethod]
        public async Task ListPlayerLabelsLimit10()
        {
            // Arrange
            var limit = 10;
            var query = new Query
            {
                Limit = limit
            };

            // Act
            var labels = await _coc.Labels.GetPlayerLabelsAsync(query);

            // Assert
            Assert.IsNotNull(labels.Items);
            Assert.AreEqual(limit, labels.Items.Count);
        }
    }
}
