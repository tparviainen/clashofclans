namespace ClashOfClans.Models
{
    public class Player : Identity
    {
        public int TownHallLevel { get; set; }

        public int? TownHallWeaponLevel { get; set; }

        public int ExpLevel { get; set; }

        public int Trophies { get; set; }

        /// <summary>
        /// All time best
        /// </summary>
        public int BestTrophies { get; set; }

        /// <summary>
        /// War stars won
        /// </summary>
        public int WarStars { get; set; }

        /// <summary>
        /// Attacks won
        /// </summary>
        public int AttackWins { get; set; }

        /// <summary>
        /// Defenses won
        /// </summary>
        public int DefenseWins { get; set; }

        public int? BuilderHallLevel { get; set; }

        public Role? Role { get; set; }

        public WarPreference? WarPreference { get; set; }

        /// <summary>
        /// Troops donated
        /// </summary>
        public int Donations { get; set; }

        /// <summary>
        /// Troops received
        /// </summary>
        public int DonationsReceived { get; set; }

        public int BuilderBaseTrophies { get; set; }

        public int BestBuilderBaseTrophies { get; set; }

        /// <summary>
        /// Total capital contribution
        /// </summary>
        public int ClanCapitalContributions { get; set; }

        public PlayerClan? Clan { get; set; }

        public League? League { get; set; }

        public PlayerLegendStatistics? LegendStatistics { get; set; }

        public PlayerAchievementProgressList Achievements { get; set; } = default!;

        public PlayerItemLevelList Troops { get; set; } = default!;

        public PlayerItemLevelList Heroes { get; set; } = default!;

        public PlayerItemLevelList HeroEquipment { get; set; } = default!;

        public PlayerItemLevelList Spells { get; set; } = default!;

        /// <summary>
        /// Labels to describe player's play style
        /// </summary>
        public LabelList Labels { get; set; } = default!;

        public PlayerHouse? PlayerHouse { get; set; }

        public BuilderBaseLeague? BuilderBaseLeague { get; set; }
    }
}
