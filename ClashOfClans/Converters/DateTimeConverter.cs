using Newtonsoft.Json;
using System;

namespace ClashOfClans.Converters
{
    internal class DateTimeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var dateTimeString = reader.Value as string;

            //                                         '20190319T022619.000Z'
            return DateTime.ParseExact(dateTimeString, "yyyyMMddTHHmmss.fffZ", System.Globalization.CultureInfo.InvariantCulture);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
