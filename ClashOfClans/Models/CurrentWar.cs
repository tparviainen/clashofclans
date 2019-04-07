using System;

namespace ClashOfClans.Models
{
    public class CurrentWar
    {
        public State State { get; set; }

        public int? TeamSize { get; set; }

        public DateTime PreparationStartTime { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public WarClan Clan { get; set; }

        public WarClan Opponent { get; set; }

        public override string ToString()
        {
            return $"CurrentWar: State '{State}', {Clan.Tag} vs {Opponent.Tag}";
        }
    }
}
