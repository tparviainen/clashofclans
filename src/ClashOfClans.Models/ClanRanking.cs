namespace ClashOfClans.Models
{
    public class ClanRanking : Identity
    {
        private int? _clanLevel;
        private int? _members;
        private int? _clanPoints;
        private int? _rank;
        private int? _previousRank;

        public Location Location { get; set; } = default!;

        public UrlContainer BadgeUrls { get; set; } = default!;

        public int ClanLevel { get => _clanLevel ?? default; set => _clanLevel = value; }

        public int Members { get => _members ?? default; set => _members = value; }

        public int ClanPoints { get => _clanPoints ?? default; set => _clanPoints = value; }

        public int Rank { get => _rank ?? default; set => _rank = value; }

        public int PreviousRank { get => _previousRank ?? default; set => _previousRank = value; }
    }
}
