using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
            foreach (var modelName in _apiModelNames)
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
                if (!_apiModelNames.Contains(modelName))
                {
                    Trace.WriteLine($"Extra: {modelName}");
                    count++;
                }
            }

            // Assert
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void CheckModelProperties()
        {
            // Arrange
            var count = 0;

            // Act
            foreach (var modelName in _apiModelNames)
            {
                var properties = GetModelProperties(modelName);
                var assemblyModel = _assemblyModels.SingleOrDefault(t => t.Name.Equals(modelName, StringComparison.InvariantCultureIgnoreCase));
                if (assemblyModel != null)
                {
                    foreach (var property in assemblyModel.GetProperties())
                    {
                        if (SkipProperty(property))
                        {
                            continue;
                        }

                        if (properties.ContainsKey(property.Name))
                        {
                            properties.Remove(property.Name);
                        }
                        else
                        {
                            Trace.WriteLine($"Extra: {assemblyModel.Name} = '{property}'");
                            count++;
                        }
                    }

                    foreach (var property in properties)
                    {
                        Trace.WriteLine($"Missing: {modelName} = '{property.Value} {property.Key}'");
                    }
                }
            }

            // Assert
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void CheckModelTypes()
        {
            // Arrange
            var count = 0;

            // Act
            foreach (var modelName in _apiModelNames)
            {
                var properties = GetModelProperties(modelName);
                var assemblyModel = _assemblyModels.SingleOrDefault(t => t.Name.Equals(modelName, StringComparison.InvariantCultureIgnoreCase));
                if (assemblyModel != null)
                {
                    foreach (var property in assemblyModel.GetProperties())
                    {
                        if (SkipProperty(property))
                        {
                            continue;
                        }

                        if (properties.TryGetValue(property.Name, out string typeName))
                        {
                            var type = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                            var match = PropertyTypesMatch(type, typeName);

                            if (!match)
                            {
                                Trace.WriteLine($"Mismatch: {modelName}.{property.Name} type {type.FullName} --> {typeName}");
                                count++;
                            }
                        }
                    }
                }
            }

            // Assert
            Assert.AreEqual(0, count);
        }
    }
}
