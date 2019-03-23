using ClashOfClans.Converters;
using Newtonsoft.Json;
using System;

namespace ClashOfClans.Models
{
    public class WarLogEntry
    {
        public string Result;

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime EndTime;

        public int? TeamSize;

        public WarClan Clan;

        public WarClan Opponent;
    }
}