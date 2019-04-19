namespace ClashOfClans.Models
{
    public class PlayerDetail : Identity
    {
        public int? TownHallLevel { get; set; }

        public int? TownHallWeaponLevel { get; set; }

        public int? ExpLevel { get; set; }

        public int? Trophies { get; set; }

        public int? BestTrophies { get; set; }

        public int? WarStars { get; set; }

        public int? AttackWins { get; set; }

        public int? DefenseWins { get; set; }

        public int? BuilderHallLevel { get; set; }

        public int? VersusTrophies { get; set; }

        public int? BestVersusTrophies { get; set; }

        public int? VersusBattleWins { get; set; }

        public Role Role { get; set; }

        public int? Donations { get; set; }

        public int? DonationsReceived { get; set; }

        public InlineModel1 Clan { get; set; }

        public League League { get; set; }

        public InlineModel2 LegendStatistics { get; set; }

        public AchievementList[] Achievements { get; set; }

        public int? VersusBattleWinCount { get; set; }

        public PlayerItemLevelList[] Troops { get; set; }

        public PlayerItemLevelList[] Heroes { get; set; }

        public PlayerItemLevelList[] Spells { get; set; }
    }
}
