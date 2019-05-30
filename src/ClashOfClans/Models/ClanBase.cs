namespace ClashOfClans.Models
{
    public class ClanBase : Identity
    {
        public Type? Type { get; set; }

        public Location Location { get; set; }

        public UrlContainer BadgeUrls { get; set; }

        public int? ClanLevel { get; set; }

        public int? ClanPoints { get; set; }

        public int? ClanVersusPoints { get; set; }

        /// <summary>
        /// Minimum trophies to join
        /// </summary>
        public int? RequiredTrophies { get; set; }

        public WarFrequency? WarFrequency { get; set; }

        public int? WarWinStreak { get; set; }

        public int? WarWins { get; set; }

        public bool? IsWarLogPublic { get; set; }

        public int? Members { get; set; }

        public int? WarTies { get; set; }

        public int? WarLosses { get; set; }

        public override string ToString()
        {
            return $"Clan: {base.ToString()}";
        }
    }
}
