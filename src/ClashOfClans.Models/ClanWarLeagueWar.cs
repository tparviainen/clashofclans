using System;

namespace ClashOfClans.Models
{
    public class ClanWarLeagueWar : WarBase
    {
        private DateTime? _warStartTime;

        public ClanWarLeagueWarClan Clan { get; set; } = default!;

        public ClanWarLeagueWarClan Opponent { get; set; } = default!;

        public DateTime WarStartTime { get => _warStartTime ?? default; set => _warStartTime = value; }
    }
}
