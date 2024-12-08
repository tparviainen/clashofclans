namespace ClashOfClans.Models
{
    public class ClanCapitalRanking : Identity
    {
        public Location Location { get; set; } = default!;

        public UrlContainer BadgeUrls { get; set; } = default!;

        public int ClanLevel { get; set; }

        public int Members { get; set; }

        public int Rank { get; set; }

        public int PreviousRank { get; set; }

        public int ClanCapitalPoints { get; set; }
    }
}
