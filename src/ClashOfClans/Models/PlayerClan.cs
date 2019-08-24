namespace ClashOfClans.Models
{
    public class PlayerClan : Identity
    {
        public int? ClanLevel { get; set; }

        public UrlContainer BadgeUrls { get; set; }
    }
}
