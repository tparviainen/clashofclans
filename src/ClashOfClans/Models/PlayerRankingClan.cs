namespace ClashOfClans.Models
{
    public class PlayerRankingClan : Identity
    {
        public int? ClanLevel { get; set; }

        public UrlContainer BadgeUrls { get; set; }

        public int? TownHallLevel { get; set; }
    }
}
