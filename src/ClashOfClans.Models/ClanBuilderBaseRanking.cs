namespace ClashOfClans.Models
{
    public class ClanBuilderBaseRanking : Identity
    {
        private int? _members;
        private int? _clanLevel;
        private int? _rank;
        private int? _previousRank;
        private int? _clanBuilderBasePoints;

        public Location? Location { get; set; }

        public int Members { get => _members ?? default; set => _members = value; }

        public int ClanLevel { get => _clanLevel ?? default; set => _clanLevel = value; }

        public int Rank { get => _rank ?? default; set => _rank = value; }

        public int PreviousRank { get => _previousRank ?? default; set => _previousRank = value; }

        public int ClanBuilderBasePoints { get => _clanBuilderBasePoints ?? default; set => _clanBuilderBasePoints = value; }

        public UrlContainer BadgeUrls { get; set; } = default!;
    }
}
