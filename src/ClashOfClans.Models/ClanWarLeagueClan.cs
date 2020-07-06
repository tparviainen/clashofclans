namespace ClashOfClans.Models
{
    public class ClanWarLeagueClan : Identity
    {
        private int? clanLevel;

        public int ClanLevel { get => clanLevel ?? default; set => clanLevel = value; }

        public UrlContainer BadgeUrls { get; set; } = default!;

        public ClanWarLeagueClanMemberList Members { get; set; } = default!;
    }
}
