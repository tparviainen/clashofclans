using System;

namespace ClashOfClans.Models
{
    public class CurrentWar
    {
        public string State;

        public int? TeamSize;

        public DateTime PreparationStartTime;

        public DateTime StartTime;

        public DateTime EndTime;

        public WarClan Clan;

        public WarClan Opponent;

        public override string ToString()
        {
            return $"CurrentWar: State '{State}', {Clan.Tag} vs {Opponent.Tag}";
        }
    }
}
