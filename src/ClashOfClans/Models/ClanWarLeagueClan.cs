namespace ClashOfClans.Models
{
    public class ClanWarLeagueClan : Identity
    {
        public int? ClanLevel { get; set; }

        public UrlContainer BadgeUrls { get; set; }

        public ClanWarLeagueClanMemberList Members { get; set; }
    }
}
