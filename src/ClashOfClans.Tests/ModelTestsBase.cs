using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

        /// <summary>
        /// Skips specific properties that are in the C# model but do not exist
        /// in the SC API model.
        /// </summary>
        protected bool SkipProperty(PropertyInfo propertyInfo)
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

        /// <summary>
        /// Checks that model type on assembly matches to the one mentioned in the API
        /// documentation.
        /// </summary>
        protected bool PropertyTypesMatch(Type type, string typeName)
        {
            bool match;

            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Boolean:
                    match = typeName == "boolean";
                    break;

                case TypeCode.Int32:
                    if (type.IsEnum)
                        match = typeName == "string";
                    else
                        match = typeName == "integer";
                    break;

                case TypeCode.Single:
                    match = typeName == "Float";
                    break;

                case TypeCode.String:
                case TypeCode.DateTime:
                    match = typeName == "string";
                    break;

                default:
                    match = typeName.Equals(type.Name);
                    break;
            }

            return match;
        }
    }
}
