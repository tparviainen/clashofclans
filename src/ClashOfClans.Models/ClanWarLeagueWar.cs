using System;

namespace ClashOfClans.Models
{
    public class ClanWarLeagueWar : WarBase
    {
        public ClanWarLeagueWarClan Clan { get; set; } = default!;

        public ClanWarLeagueWarClan Opponent { get; set; } = default!;

        public DateTime WarStartTime { get; set; }
    }
}
