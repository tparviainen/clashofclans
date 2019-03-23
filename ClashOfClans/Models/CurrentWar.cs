using ClashOfClans.Converters;
using Newtonsoft.Json;
using System;

namespace ClashOfClans.Models
{
    public class CurrentWar
    {
        public string State;

        public int? TeamSize;

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime PreparationStartTime;

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime StartTime;

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime EndTime;

        public WarClan Clan;

        public WarClan Opponent;

        public override string ToString()
        {
            return $"CurrentWar: State '{State}', {Clan.Tag} vs {Opponent.Tag}";
        }
    }
}
