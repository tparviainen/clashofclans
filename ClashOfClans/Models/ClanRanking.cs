namespace ClashOfClans.Models
{
    public class ClanRanking : Identity
    {
        public Location Location;

        public UrlContainer BadgeUrls;

        public int? ClanLevel;

        public int? Members;

        public int? ClanPoints;

        public int? Rank;

        public int? PreviousRank;

        public int? ClanVersusPoints;
    }
}