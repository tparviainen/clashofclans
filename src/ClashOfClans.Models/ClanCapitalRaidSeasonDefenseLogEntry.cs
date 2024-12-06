namespace ClashOfClans.Models
{
    public class ClanCapitalRaidSeasonDefenseLogEntry
    {
        public ClanCapitalRaidSeasonClanInfo Attacker { get; set; } = default!;

        public int AttackCount { get; set; }

        public int DistrictCount { get; set; }

        public int DistrictsDestroyed { get; set; }

        public ClanCapitalRaidSeasonDistrictList Districts { get; set; } = default!;
    }
}
