using ClashOfClans.Models;
using ClashOfClans.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ClashOfClans.Tests.Integration
{
    [TestClass]
    public class LabelsTests : TestsBase
    {
        [TestMethod]
        public async Task GetClanLabels()
        {
            // Arrange

            // Act
            var labels = (LabelList)await _coc.Labels.GetClanLabelsAsync();

            // Assert
            Assert.IsNotNull(labels);
            labels.ForEach(label => Trace.WriteLine(label.Dump()));
        }

        [TestMethod]
        public async Task Get5ClanLabels()
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
            Assert.AreEqual(limit, labels.Count, $"The amount of clan labels was different to requested amount.");
        }

        [TestMethod]
        public async Task GetPlayerLabels()
        {
            // Arrange

            // Act
            var labels = (LabelList)await _coc.Labels.GetPlayerLabelsAsync();

            // Assert
            Assert.IsNotNull(labels);
            labels.ForEach(label => Trace.WriteLine(label.Dump()));
        }

        [TestMethod]
        public async Task Get10PlayerLabels()
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
            Assert.AreEqual(limit, labels.Count, $"The amount of player labels was different to requested amount.");
        }
    }
}
