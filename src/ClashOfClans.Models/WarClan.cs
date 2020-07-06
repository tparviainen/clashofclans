namespace ClashOfClans.Models
{
    public class WarClan
    {
        private int? _clanLevel;
        private int? _stars;
        private float? _destructionPercentage;

        public string? Tag { get; set; }

        public string? Name { get; set; }

        public UrlContainer BadgeUrls { get; set; } = default!;

        public int ClanLevel { get => _clanLevel ?? default; set => _clanLevel = value; }

        public int? Attacks { get; set; }

        public int Stars { get => _stars ?? default; set => _stars = value; }

        public float DestructionPercentage { get => _destructionPercentage ?? default; set => _destructionPercentage = value; }

        public int? ExpEarned { get; set; }

        public ClanWarMemberList? Members { get; set; }
    }
}
