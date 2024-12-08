namespace ClashOfClans.Models
{
    public class WarClan
    {
        public string? Tag { get; set; }

        public string? Name { get; set; }

        public UrlContainer BadgeUrls { get; set; } = default!;

        public int ClanLevel { get; set; }

        public int? Attacks { get; set; }

        public int Stars { get; set; }

        public float? DestructionPercentage { get; set; }

        public int? ExpEarned { get; set; }

        public ClanWarMemberList? Members { get; set; }
    }
}
