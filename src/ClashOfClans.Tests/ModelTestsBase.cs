using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ClashOfClans.Tests
{
    public class ModelTestsBase
    {
        protected IEnumerable<string> _apiModels;
        protected IEnumerable<Type> _assemblyModels;

        public ModelTestsBase()
        {
            _apiModels = GetModelsFromFiles().OrderBy(n => n);
            _assemblyModels = GetModelsFromAssembly("ClashOfClans.Models").OrderBy(t => t.Name);
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
    }
}
