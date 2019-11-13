using ClashOfClans.Models;
using ClashOfClans.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
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
            var labels = (LabelList)await _coc.Labels.GetClanLabelsAsync();

            // Assert
            Assert.IsNotNull(labels);
            labels.ForEach(label => Trace.WriteLine(label.Dump()));
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
            var labels = (LabelList)await _coc.Labels.GetClanLabelsAsync(query);

            // Assert
            Assert.IsNotNull(labels);
            Assert.AreEqual(limit, labels.Count);
        }

        [TestMethod]
        public async Task ListPlayerLabels()
        {
            // Arrange

            // Act
            var labels = (LabelList)await _coc.Labels.GetPlayerLabelsAsync();

            // Assert
            Assert.IsNotNull(labels);
            labels.ForEach(label => Trace.WriteLine(label.Dump()));
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
            var labels = (LabelList)await _coc.Labels.GetPlayerLabelsAsync(query);

            // Assert
            Assert.IsNotNull(labels);
            Assert.AreEqual(limit, labels.Count);
        }
    }
}
