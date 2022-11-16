using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;
using System.Text;

namespace ClashOfClans.Core.Serialization
{
    internal class MessageSerializer
    {
        public static T Deserialize<T>(string data) where T : class
        {
            using var ms = new MemoryStream(Encoding.UTF8.GetBytes(data));
            var serializer = new JsonSerializer
            {
#if DEBUG
                MissingMemberHandling = MissingMemberHandling.Error,
#endif
                DateFormatString = "yyyyMMddTHHmmss.fffK"
            };

            using var sr = new StreamReader(ms);
            var reader = new JsonTextReader(sr);
            return serializer.Deserialize<T>(reader)!;
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
