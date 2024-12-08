using System.Collections.Generic;

namespace ClashOfClans.Models
{
    public class Clan : Identity
    {
        public string? Description { get; set; }

        public List<ClanMember>? MemberList { get; set; }

        public Type Type { get; set; }

        /// <summary>
        /// Clan location
        /// </summary>
        public Location? Location { get; set; }

        public UrlContainer BadgeUrls { get; set; } = default!;

        public int ClanLevel { get; set; }

        public int ClanPoints { get; set; }

        public int ClanBuilderBasePoints { get; set; }

        public int ClanCapitalPoints { get; set; }

        /// <summary>
        /// Minimum trophies to join
        /// </summary>
        public int RequiredTrophies { get; set; }

        public int RequiredTownhallLevel { get; set; }

        public ClanCapital? ClanCapital { get; set; }

        public WarFrequency? WarFrequency { get; set; }

        public Language? ChatLanguage { get; set; }

        public int WarWinStreak { get; set; }

        /// <summary>
        /// Wars won
        /// </summary>
        public int WarWins { get; set; }

        public int RequiredBuilderBaseTrophies { get; set; }

        public bool IsFamilyFriendly { get; set; }

        public bool IsWarLogPublic { get; set; }

        public WarLeague WarLeague { get; set; } = default!;

        public CapitalLeague CapitalLeague { get; set; } = default!;

        public int Members { get; set; }

        public int? WarTies { get; set; }

        public int? WarLosses { get; set; }

        /// <summary>
        /// Labels to describe clan
        /// </summary>
        public LabelList Labels { get; set; } = default!;
    }
}
