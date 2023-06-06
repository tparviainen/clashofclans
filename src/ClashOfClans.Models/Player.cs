namespace ClashOfClans.Models
{
    public class Player : Identity
    {
        private int? _townHallLevel;
        private int? _expLevel;
        private int? _trophies;
        private int? _bestTrophies;
        private int? _warStars;
        private int? _attackWins;
        private int? _defenseWins;
        private int? _versusTrophies;
        private int? _bestVersusTrophies;
        private int? _versusBattleWins;
        private int? _donations;
        private int? _donationsReceived;
        private int? _builderBaseTrophies;
        private int? _bestBuilderBaseTrophies;
        private int? _clanCapitalContributions;
        private int? _versusBattleWinCount;

        public int TownHallLevel { get => _townHallLevel ?? default; set => _townHallLevel = value; }

        public int? TownHallWeaponLevel { get; set; }

        public int ExpLevel { get => _expLevel ?? default; set => _expLevel = value; }

        public int Trophies { get => _trophies ?? default; set => _trophies = value; }

        /// <summary>
        /// All time best
        /// </summary>
        public int BestTrophies { get => _bestTrophies ?? default; set => _bestTrophies = value; }

        /// <summary>
        /// War stars won
        /// </summary>
        public int WarStars { get => _warStars ?? default; set => _warStars = value; }

        /// <summary>
        /// Attacks won
        /// </summary>
        public int AttackWins { get => _attackWins ?? default; set => _attackWins = value; }

        /// <summary>
        /// Defenses won
        /// </summary>
        public int DefenseWins { get => _defenseWins ?? default; set => _defenseWins = value; }

        public int? BuilderHallLevel { get; set; }

        public int VersusTrophies { get => _versusTrophies ?? default; set => _versusTrophies = value; }

        /// <summary>
        /// All time best
        /// </summary>
        public int BestVersusTrophies { get => _bestVersusTrophies ?? default; set => _bestVersusTrophies = value; }

        public int VersusBattleWins { get => _versusBattleWins ?? default; set => _versusBattleWins = value; }

        public Role? Role { get; set; }

        public WarPreference? WarPreference { get; set; }

        /// <summary>
        /// Troops donated
        /// </summary>
        public int Donations { get => _donations ?? default; set => _donations = value; }

        /// <summary>
        /// Troops received
        /// </summary>
        public int DonationsReceived { get => _donationsReceived ?? default; set => _donationsReceived = value; }

        public int BuilderBaseTrophies { get => _builderBaseTrophies ?? default; set => _builderBaseTrophies = value; }

        public int BestBuilderBaseTrophies { get => _bestBuilderBaseTrophies ?? default; set => _bestBuilderBaseTrophies = value; }

        /// <summary>
        /// Total capital contribution
        /// </summary>
        public int ClanCapitalContributions { get => _clanCapitalContributions ?? default; set => _clanCapitalContributions = value; }

        public PlayerClan? Clan { get; set; }

        public League? League { get; set; }

        public PlayerLegendStatistics? LegendStatistics { get; set; }

        public PlayerAchievementProgressList Achievements { get; set; } = default!;

        public int VersusBattleWinCount { get => _versusBattleWinCount ?? default; set => _versusBattleWinCount = value; }

        public PlayerItemLevelList Troops { get; set; } = default!;

        public PlayerItemLevelList Heroes { get; set; } = default!;

        public PlayerItemLevelList Spells { get; set; } = default!;

        /// <summary>
        /// Labels to describe player's play style
        /// </summary>
        public LabelList Labels { get; set; } = default!;

        public PlayerHouse? PlayerHouse { get; set; }

        public BuilderBaseLeague? BuilderBaseLeague { get; set; }
    }
}
