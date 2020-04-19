using System;

namespace ClashOfClans.Models
{
    public class ClanWarLeagueWar : WarBase
    {
        public ClanWarLeagueWarClan Clan { get; set; }

        public ClanWarLeagueWarClan Opponent { get; set; }

        public DateTime WarStartTime { get; set; }
    }
}
