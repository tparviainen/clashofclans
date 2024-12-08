namespace ClashOfClans.Models
{
    public class ClanWar : WarBase
    {
        public int? AttacksPerMember { get; set; }

        public BattleModifier? BattleModifier { get; set; }

        public WarClan Clan { get; set; } = default!;

        public WarClan Opponent { get; set; } = default!;
    }
}
