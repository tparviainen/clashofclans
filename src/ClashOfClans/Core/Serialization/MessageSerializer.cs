using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClashOfClans.Core.Serialization
{
    internal class MessageSerializer
    {
        public static T Deserialize<T>(string data, out HashSet<string> uninitializedProperties) where T : class
        {
            using var ms = new MemoryStream(Encoding.UTF8.GetBytes(data));
            var serializer = new JsonSerializer
            {
#if DEBUG
                MissingMemberHandling = MissingMemberHandling.Error,
                ContractResolver = new TrackingContractResolver(out var trackedPropertyIdentifiers),
#endif
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatString = "yyyyMMddTHHmmss.fffK"
            };

            using var sr = new StreamReader(ms);
            var reader = new JsonTextReader(sr);
            var result = serializer.Deserialize<T>(reader)!;

            uninitializedProperties = new HashSet<string>();
#if DEBUG
            foreach (var property in trackedPropertyIdentifiers)
            {
                var parts = property.Split('.');
                var (hashCode, typeName, propertyName) = (parts[0], parts[1], parts[2]);

                var fullyQualifiedName = $"ClashOfClans.Models.{typeName}, {typeof(Models.Player).Assembly.FullName}";
                var type = Type.GetType(fullyQualifiedName);
                if (!(type is null))
                {
                    foreach (var propertyInfo in type.GetProperties())
                    {
                        var nameWithoutHashCode = $"{type.Name}.{propertyInfo.Name}";
                        var nameWithHashCode = $"{hashCode}.{nameWithoutHashCode}";

                        if (!trackedPropertyIdentifiers.Contains(nameWithHashCode))
                        {
                            uninitializedProperties.Add(nameWithoutHashCode);
                        }
                    }
                }
            }
#endif

            return result;
        }

        public static string Serialize(object value)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            return JsonConvert.SerializeObject(value, settings);
        }
    }
}
