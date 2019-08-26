using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

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

                        if (!properties.ContainsKey(property.Name))
                        {
                            Trace.WriteLine($"Extra: {assemblyModel.Name} = {property.Name}");
                            count++;
                        }
                    }
                }
                else
                {
                    Trace.WriteLine($"Missing: {modelName}");
                }
            }

            // Assert
            Assert.AreEqual(0, count);
        }

        /// <summary>
        /// Skips specific properties that are in the C# model but do not exist
        /// in the SC API model.
        /// </summary>
        private bool SkipProperty(PropertyInfo propertyInfo)
        {
            // Skip properties that are not declared in CoC assembly. This means
            // properties that come via List<T> inheritance.
            if (propertyInfo.Module.Assembly != typeof(ClashOfClansApi).Assembly)
            {
                return true;
            }

            // Indexer has "Item" property that is read only and should be skipped
            if (!propertyInfo.CanWrite)
            {
                return true;
            }

            // Properties declared for searching functionality should be skipped
            if (propertyInfo.DeclaringType == typeof(Models.Queryable))
            {
                return true;
            }

            return false;
        }
    }
}
