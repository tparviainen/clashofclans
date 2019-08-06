using System;

namespace ClashOfClans.Models
{
    public class CurrentWar : WarBase
    {
        public WarClan Clan { get; set; }

        public WarClan Opponent { get; set; }

        public override string ToString()
        {
            return $"CurrentWar: State '{State}', {Clan.Tag} vs {Opponent.Tag}";
        }
    }
}
