namespace ClashOfClans.Models
{
    public class ClanCapitalRaidSeasonDistrict
    {
        private int? _id;
        private int? _stars;
        private int? _districtHallLevel;
        private int? _destructionPercent;
        private int? _attackCount;
        private int? _totalLooted;

        public int Id { get => _id ?? default; set => _id = value; }

        public int Stars { get => _stars ?? default; set => _stars = value; }

        public string Name { get; set; } = default!;

        public int DistrictHallLevel { get => _districtHallLevel ?? default; set => _districtHallLevel = value; }

        public int DestructionPercent { get => _destructionPercent ?? default; set => _destructionPercent = value; }

        public int AttackCount { get => _attackCount ?? default; set => _attackCount = value; }

        public int TotalLooted { get => _totalLooted ?? default; set => _totalLooted = value; }

        public ClanCapitalRaidSeasonAttackList? Attacks { get; set; }
    }
}
