namespace ClashOfClans.Models
{
    public class ClanBuilderBaseRanking : Identity
    {
        public Location? Location { get; set; }

        public int Members { get; set; }

        public int ClanLevel { get; set; }

        public int Rank { get; set; }

        public int PreviousRank { get; set; }

        public int ClanBuilderBasePoints { get; set; }

        public UrlContainer BadgeUrls { get; set; } = default!;
    }
}
