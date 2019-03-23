using ClashOfClans.Converters;
using Newtonsoft.Json;
using System;

namespace ClashOfClans.Models
{
    public class ClanWarLeagueWar
    {
        public string State;

        public int? TeamSize;

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime PreparationStartTime;

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime StartTime;

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime EndTime;

        public ClanWarLeagueWarClan Clan;

        public ClanWarLeagueWarClan Opponent;

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime WarStartTime;
    }
}
