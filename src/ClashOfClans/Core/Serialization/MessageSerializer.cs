using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace ClashOfClans.Core.Serialization
{
    internal class MessageSerializer
    {
        public T Deserialize<T>(string data) where T : class
        {
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(data)))
            {
                var serializer = new JsonSerializer
                {
#if DEBUG
                    MissingMemberHandling = MissingMemberHandling.Error,
#endif
                    DateFormatString = "yyyyMMddTHHmmss.fffK"
                };

                using (var stream = new StreamReader(ms))
                {
                    var reader = new JsonTextReader(stream);
                    return serializer.Deserialize<T>(reader)!;
                }
            }
        }
    }
}
