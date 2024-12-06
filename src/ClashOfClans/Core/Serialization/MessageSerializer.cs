using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                ContractResolver = new TrackingContractResolver(out var initialisedProperties),
#endif
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatString = "yyyyMMddTHHmmss.fffK"
            };

            using var sr = new StreamReader(ms);
            var reader = new JsonTextReader(sr);
            var result = serializer.Deserialize<T>(reader)!;

#if DEBUG
            uninitializedProperties = new HashSet<string>(initialisedProperties.Where(x => x.EndsWith(".null")).Select(p =>
            {
                var parts = p.Split('.');
                return $"{parts[1]}.{parts[2]}.{parts[3]}";
            }));

            foreach (var property in initialisedProperties.Where(x => !x.EndsWith(".null")))
            {
                var hashCode = property.Split('.')[0];
                var typeName = property.Split('.')[1];
                var propertyName = property.Split('.')[2];

                var fullyQualifiedName = $"ClashOfClans.Models.{typeName}, {typeof(Models.Player).Assembly.FullName}";
                var type = Type.GetType(fullyQualifiedName);
                if (type is null)
                {
                    continue;
                }

                foreach (var propertyInfo in type.GetProperties())
                {
                    var nameWithoutHashCode = $"{type.Name}.{propertyInfo.Name}";
                    var nameWithHashCode = $"{hashCode}.{nameWithoutHashCode}";

                    if (initialisedProperties.Contains(nameWithHashCode))
                    {
                        continue;
                    }

                    uninitializedProperties.Add(nameWithoutHashCode);
                }
            }
#else
            uninitializedProperties = new HashSet<string>();
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
