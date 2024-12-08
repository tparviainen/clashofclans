using System;

namespace ClashOfClans.Models
{
    public class ClanWarLogEntry
    {
        public Result? Result { get; set; }

        public DateTime EndTime { get; set; }

        public int? TeamSize { get; set; }

        public int? AttacksPerMember { get; set; }

        public BattleModifier BattleModifier { get; set; }

        public WarClan Clan { get; set; } = default!;

        public WarClan Opponent { get; set; } = default!;
    }
}
