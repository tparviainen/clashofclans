namespace ClashOfClans.Models
{
    public class ClanCapitalRaidSeasonAttackLogEntry
    {
        private int? _attackCount;
        private int? _districtCount;
        private int? _districtsDestroyed;

        public ClanCapitalRaidSeasonClanInfo Defender { get; set; } = default!;

        public int AttackCount { get => _attackCount ?? default; set => _attackCount = value; }

        public int DistrictCount { get => _districtCount ?? default; set => _districtCount = value; }

        public int DistrictsDestroyed { get => _districtsDestroyed ?? default; set => _districtsDestroyed = value; }

        public ClanCapitalRaidSeasonDistrictList Districts { get; set; } = default!;
    }
}
