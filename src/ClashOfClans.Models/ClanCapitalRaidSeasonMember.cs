namespace ClashOfClans.Models
{
    public class ClanCapitalRaidSeasonMember
    {
        public string Tag { get; set; } = default!;

        public string Name { get; set; } = default!;

        public int Attacks { get; set; }

        public int AttackLimit { get; set; }

        public int BonusAttackLimit { get; set; }

        public int CapitalResourcesLooted { get; set; }
    }
}
