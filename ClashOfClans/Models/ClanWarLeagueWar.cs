using System;

namespace ClashOfClans.Models
{
    public class ClanWarLeagueWar
    {
        public string State { get; set; }

        public int? TeamSize { get; set; }

        public DateTime PreparationStartTime { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public ClanWarLeagueWarClan Clan { get; set; }

        public ClanWarLeagueWarClan Opponent { get; set; }

        public DateTime WarStartTime { get; set; }
    }
}
