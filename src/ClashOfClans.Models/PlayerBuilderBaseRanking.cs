namespace ClashOfClans.Models
{
    public class PlayerBuilderBaseRanking : Identity
    {
        private int? _expLevel;
        private int? _rank;
        private int? _previousRank;
        private int? _builderBaseTrophies;

        public int ExpLevel { get => _expLevel ?? default; set => _expLevel = value; }

        public int Rank { get => _rank ?? default; set => _rank = value; }

        public int PreviousRank { get => _previousRank ?? default; set => _previousRank = value; }

        public int BuilderBaseTrophies { get => _builderBaseTrophies ?? default; set => _builderBaseTrophies = value; }

        public PlayerRankingClan? Clan { get; set; }

        public BuilderBaseLeague BuilderBaseLeague { get; set; } = default!;
    }
}
