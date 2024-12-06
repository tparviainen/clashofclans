namespace ClashOfClans.Models
{
    public class ClanCapitalRaidSeasonClanInfo
    {
        public string Tag { get; set; } = default!;

        public string Name { get; set; } = default!;

        public int Level { get; set; }

        public UrlContainer BadgeUrls { get; set; } = default!;
    }
}
