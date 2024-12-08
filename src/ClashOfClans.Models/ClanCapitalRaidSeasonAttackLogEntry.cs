namespace ClashOfClans.Models
{
    public class ClanCapitalRaidSeasonAttackLogEntry
    {
        public ClanCapitalRaidSeasonClanInfo Defender { get; set; } = default!;

        public int AttackCount { get; set; }

        public int DistrictCount { get; set; }

        public int DistrictsDestroyed { get; set; }

        public ClanCapitalRaidSeasonDistrictList Districts { get; set; } = default!;
    }
}
