using System.Collections.Generic;

namespace ClashOfClans.Models
{
    public class Clan : Identity
    {
        private Type? _type;
        private int? _clanLevel;
        private int? _clanPoints;
        private int? _clanVersusPoints;
        private int? _requiredTrophies;
        private WarFrequency? _warFrequency;
        private int? _warWinStreak;
        private int? _warWins;
        private bool? _isWarLogPublic;
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

        public int ClanVersusPoints { get => _clanVersusPoints ?? default; set => _clanVersusPoints = value; }

        /// <summary>
        /// Minimum trophies to join
        /// </summary>
        public int RequiredTrophies { get => _requiredTrophies ?? default; set => _requiredTrophies = value; }

        public WarFrequency WarFrequency { get => _warFrequency ?? default; set => _warFrequency = value; }

        public int WarWinStreak { get => _warWinStreak ?? default; set => _warWinStreak = value; }

        /// <summary>
        /// Wars won
        /// </summary>
        public int WarWins { get => _warWins ?? default; set => _warWins = value; }

        public bool IsWarLogPublic { get => _isWarLogPublic ?? default; set => _isWarLogPublic = value; }

        public WarLeague WarLeague { get; set; } = default!;

        public int Members { get => _members ?? default; set => _members = value; }

        public int? WarTies { get; set; }

        public int? WarLosses { get; set; }

        /// <summary>
        /// Labels to describe clan
        /// </summary>
        public LabelList Labels { get; set; } = default!;
    }
}
