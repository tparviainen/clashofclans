using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Linq;

namespace ClashOfClans.Tests
{
    [TestClass]
    public class ModelTests : ModelTestsBase
    {
        [TestMethod]
        public void ModelsMissingFromAssembly()
        {
            // Arrange
            var count = 0;

            // Act
            foreach (var modelName in _apiModels)
            {
                if (!_assemblyModels.Any(m => m.Name == modelName))
                {
                    Trace.WriteLine($"Missing: {modelName}");
                    count++;
                }
            }

            // Assert
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void ExtraModelsInAssembly()
        {
            // Arrange
            var count = 0;

            // Act
            foreach (var assemblyModel in _assemblyModels)
            {
                var modelName = assemblyModel.Name;
                if (!_apiModels.Contains(modelName))
                {
                    Trace.WriteLine($"Extra: {modelName}");
                    count++;
                }
            }

            // Assert
            Assert.AreEqual(0, count);
        }
    }
}
