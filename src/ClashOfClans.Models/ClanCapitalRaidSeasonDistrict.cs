namespace ClashOfClans.Models
{
    public class ClanCapitalRaidSeasonDistrict
    {
        public int Id { get; set; }

        public int Stars { get; set; }

        public string Name { get; set; } = default!;

        public int DistrictHallLevel { get; set; }

        public int DestructionPercent { get; set; }

        public int AttackCount { get; set; }

        public int TotalLooted { get; set; }

        public ClanCapitalRaidSeasonAttackList? Attacks { get; set; }
    }
}
