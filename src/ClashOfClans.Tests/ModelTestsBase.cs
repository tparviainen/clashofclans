using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ClashOfClans.Tests
{
    public class ModelTestsBase
    {
        protected IEnumerable<string> _apiModelNames;
        protected IEnumerable<Type> _assemblyModels;
        private string _models;

        public ModelTestsBase()
        {
            _apiModelNames = GetModelsFromFiles().OrderBy(n => n);
            _assemblyModels = GetModelsFromAssembly("ClashOfClans.Models").OrderBy(t => t.Name);

            _models = _models.Replace("\r\n", " ");
        }

        private ICollection<string> GetModelsFromFiles()
        {
            var files = Directory.GetFiles("Models");
            var models = new List<string>();

            foreach (var file in files)
            {
                models.AddRange(GetModelsFromText(file));
            }

            return models.Distinct().ToList();
        }

        private IEnumerable<string> GetModelsFromText(string path)
        {
            var content = File.ReadAllText(path);
            _models += content;

            var lists = Regex.Matches(content, @"\b([A-Z]\w+)\b");
            var models = new List<string>();

            foreach (Match listItem in lists)
            {
                models.Add(listItem.Value);
            }

            return models.Distinct();
        }

        private ICollection<Type> GetModelsFromAssembly(string ns)
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(t => t.IsClass && t.IsPublic && t.Namespace == ns);

            return types.ToList();
        }

        protected Dictionary<string, string> GetModelProperties(string modelName)
        {
            var pattern = $@"\b{modelName}\b ";
            pattern += "{(.*?)}";

            var models = Regex.Matches(_models, pattern);
            var values = new Dictionary<string, string>();

            foreach (Match match in models)
            {
                ParseModel(match.Groups[1].Value, values);
            }

            AddProperties(modelName, values);

            return values;
        }

        private void ParseModel(string input, Dictionary<string, string> values)
        {
            var pattern = @"(\w+) \((\w+), \w+\)";
            var properties = Regex.Matches(input, pattern);

            foreach (Match property in properties)
            {
                var propKey = property.Groups[1].Value.Trim();
                var propVal = property.Groups[2].Value.Trim();
                values.TryAdd(propKey.ToUpperFirst(), propVal);
            }
        }

        private void AddProperties(string modelName, Dictionary<string, string> values)
        {
            // List models have special properties either because the model is inherited
            // from List<T> or is a root element in the response.
            if (modelName.EndsWith("List"))
            {
                values.TryAdd("Items", null);
                values.TryAdd("Paging", null);
                values.TryAdd("Capacity", null);
                values.TryAdd("Count", null);
                values.TryAdd("Item", null);
            }
        }
    }
}
