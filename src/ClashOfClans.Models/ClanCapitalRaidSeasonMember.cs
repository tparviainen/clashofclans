namespace ClashOfClans.Models
{
    public class ClanCapitalRaidSeasonMember
    {
        private int? _attacks;
        private int? _attackLimit;
        private int? _bonusAttackLimit;
        private int? _capitalResourcesLooted;

        public string Tag { get; set; } = default!;

        public string Name { get; set; } = default!;

        public int Attacks { get => _attacks ?? default; set => _attacks = value; }

        public int AttackLimit { get => _attackLimit ?? default; set => _attackLimit = value; }

        public int BonusAttackLimit { get => _bonusAttackLimit ?? default; set => _bonusAttackLimit = value; }

        public int CapitalResourcesLooted { get => _capitalResourcesLooted ?? default; set => _capitalResourcesLooted = value; }
    }
}
