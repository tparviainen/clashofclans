namespace ClashOfClans.Models
{
    public class WarClan : Identity
    {
        public UrlContainer BadgeUrls { get; set; }

        public int? ClanLevel { get; set; }

        public int? Attacks { get; set; }

        public int? Stars { get; set; }

        public float? DestructionPercentage { get; set; }

        public int? ExpEarned { get; set; }

        public ClanWarMemberList[] Members { get; set; }
    }
}
