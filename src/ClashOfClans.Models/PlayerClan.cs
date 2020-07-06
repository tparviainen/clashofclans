namespace ClashOfClans.Models
{
    public class PlayerClan : Identity
    {
        private int? _clanLevel;

        public int ClanLevel { get => _clanLevel ?? default; set => _clanLevel = value; }

        public UrlContainer BadgeUrls { get; set; } = default!;
    }
}
