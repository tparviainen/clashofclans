using System.Collections;
using System.Collections.Generic;

namespace ClashOfClans.Extensions
{
    internal static class ObjectExtensions
    {
        private const string ClashOfClansModelsNamespace = "ClashOfClans.Models";

        /// <summary>
        /// Returns the list of 'class:property' values, which are null in the requested model.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        internal static IEnumerable<string> GetNullProperties<T>(this T data) where T : class
        {
            var dtoType = data.GetType();
            var nullProperties = new HashSet<string>();

            foreach (var property in dtoType.GetProperties())
            {
                var pType = property.PropertyType;
                var pValue = property.GetValue(data);

                if (pValue == null)
                {
                    nullProperties.Add($"{dtoType.Name}:{property.Name}");
                }
                else if (pValue is IList list)
                {
                    foreach (var item in list)
                    {
                        if (item?.GetType().Namespace == ClashOfClansModelsNamespace)
                            nullProperties.UnionWith(item.GetNullProperties());
                    }
                }
                else if (pType.IsClass && pType.Namespace == ClashOfClansModelsNamespace)
                {
                    nullProperties.UnionWith(pValue.GetNullProperties());
                }
            }

            return nullProperties;
        }
    }
}
