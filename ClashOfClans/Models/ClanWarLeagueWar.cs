using System;

namespace ClashOfClans.Models
{
    public class ClanWarLeagueWar
    {
        public string State;

        public int? TeamSize;

        public DateTime PreparationStartTime;

        public DateTime StartTime;

        public DateTime EndTime;

        public ClanWarLeagueWarClan Clan;

        public ClanWarLeagueWarClan Opponent;

        public DateTime WarStartTime;
    }
}
