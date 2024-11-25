using System.Collections.Generic;

namespace ClashOfClans.Models
{
    public class Clan : Identity
    {
        private Type? _type;
        private int? _clanLevel;
        private int? _clanPoints;
        private int? _clanBuilderBasePoints;
        private int? _clanCapitalPoints;
        private int? _requiredTrophies;
        private int? _requiredTownhallLevel;
        private int? _warWinStreak;
        private int? _warWins;
        private int? _requiredBuilderBaseTrophies;
        private bool? _isWarLogPublic;
        private bool? _isFamilyFriendly;
        private int? _members;

        public string? Description { get; set; }

        public List<ClanMember>? MemberList { get; set; }

        public Type Type { get => _type ?? default; set => _type = value; }

        /// <summary>
        /// Clan location
        /// </summary>
        public Location? Location { get; set; }

        public UrlContainer BadgeUrls { get; set; } = default!;

        public int ClanLevel { get => _clanLevel ?? default; set => _clanLevel = value; }

        public int ClanPoints { get => _clanPoints ?? default; set => _clanPoints = value; }

        public int ClanBuilderBasePoints { get => _clanBuilderBasePoints ?? default; set => _clanBuilderBasePoints = value; }

        public int ClanCapitalPoints { get => _clanCapitalPoints ?? default; set => _clanCapitalPoints = value; }

        /// <summary>
        /// Minimum trophies to join
        /// </summary>
        public int RequiredTrophies { get => _requiredTrophies ?? default; set => _requiredTrophies = value; }

        public int RequiredTownhallLevel { get => _requiredTownhallLevel ?? default; set => _requiredTownhallLevel = value; }

        public ClanCapital? ClanCapital { get; set; }

        public WarFrequency? WarFrequency { get; set; }

        public Language? ChatLanguage { get; set; }

        public int WarWinStreak { get => _warWinStreak ?? default; set => _warWinStreak = value; }

        /// <summary>
        /// Wars won
        /// </summary>
        public int WarWins { get => _warWins ?? default; set => _warWins = value; }

        public int RequiredBuilderBaseTrophies { get => _requiredBuilderBaseTrophies ?? default; set => _requiredBuilderBaseTrophies = value; }

        public bool IsFamilyFriendly { get => _isFamilyFriendly ?? default; set => _isFamilyFriendly = value; }

        public bool IsWarLogPublic { get => _isWarLogPublic ?? default; set => _isWarLogPublic = value; }

        public WarLeague WarLeague { get; set; } = default!;

        public CapitalLeague CapitalLeague { get; set; } = default!;

        public int Members { get => _members ?? default; set => _members = value; }

        public int? WarTies { get; set; }

        public int? WarLosses { get; set; }

        /// <summary>
        /// Labels to describe clan
        /// </summary>
        public LabelList Labels { get; set; } = default!;
    }
}
