using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
        internal static IEnumerable<string> GetNullMembers<T>(this T data) where T : class
        {
            var dtoType = data.GetType();
            var nullMembers = new HashSet<string>();

            // All value types have a nullable backing field
            foreach (var field in dtoType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(f => !f.FieldType.IsClass))
            {
                if (field.GetValue(data) == null)
                    nullMembers.Add(GetName(dtoType, field));
            }

            // Reference types dont have backing field
            foreach (var property in dtoType.GetProperties().Where(p => p.PropertyType.IsClass))
            {
                var pType = property.PropertyType;
                var pValue = property.GetValue(data);

                if (pValue == null)
                {
                    nullMembers.Add(GetName(dtoType, property));
                }
                else if (pValue is IList list)
                {
                    foreach (var item in list)
                    {
                        if (item?.GetType().Namespace == ClashOfClansModelsNamespace)
                            nullMembers.UnionWith(item.GetNullMembers());
                    }
                }
                else if (pType.IsClass && pType.Namespace == ClashOfClansModelsNamespace)
                {
                    nullMembers.UnionWith(pValue.GetNullMembers());
                }
            }

            return nullMembers;

            static string GetName(System.Type type, MemberInfo member)
            {
                var memberName = member.Name;

                if (IsGeneratedMemberName(memberName))
                {
                    var index = memberName.IndexOf(">k__BackingField");
                    memberName = memberName.Substring(1, index - 1);
                }
                else if (IsDeclaredMemberName(memberName))
                {
                    memberName = char.ToUpper(memberName[1]) + memberName.Substring(2);
                }

                return $"{type.Name}:{memberName}";
            }

            // Generated fields, e.g. "<property_name>k__BackingField"
            static bool IsGeneratedMemberName(string memberName) => memberName.Length > 0 && memberName[0] == '<';

            // Declared fields, e.g. "_<property_name>"
            static bool IsDeclaredMemberName(string memberName) => memberName.Length > 0 && memberName[0] == '_';
        }
    }
}
