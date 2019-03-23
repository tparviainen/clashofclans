namespace ClashOfClans.Models
{
    public class PlayerDetail : Identity
    {
        public int? TownHallLevel;

        public int? TownHallWeaponLevel;

        public int? ExpLevel;

        public int? Trophies;

        public int? BestTrophies;

        public int? WarStars;

        public int? AttackWins;

        public int? DefenseWins;

        public int? BuilderHallLevel;

        public int? VersusTrophies;

        public int? BestVersusTrophies;

        public int? VersusBattleWins;

        public string Role;

        public int? Donations;

        public int? DonationsReceived;

        public InlineModel1 Clan;

        public League League;

        public InlineModel2 LegendStatistics;

        public AchievementList[] Achievements;

        public int? VersusBattleWinCount;

        public PlayerItemLevelList[] Troops;

        public PlayerItemLevelList[] Heroes;

        public PlayerItemLevelList[] Spells;
    }
}
