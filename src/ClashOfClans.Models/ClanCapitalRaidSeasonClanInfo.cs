namespace ClashOfClans.Models
{
    public class ClanCapitalRaidSeasonClanInfo
    {
        private int? _level;

        public string Tag { get; set; } = default!;

        public string Name { get; set; } = default!;

        public int Level { get => _level ?? default; set => _level = value; }

        public UrlContainer BadgeUrls { get; set; } = default!;
    }
}
