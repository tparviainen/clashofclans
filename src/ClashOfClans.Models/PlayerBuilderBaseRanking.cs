namespace ClashOfClans.Models
{
    public class PlayerBuilderBaseRanking : Identity
    {
        private int? _expLevel;
        private int? _rank;
        private int? _previousRank;
        private int? _builderBaseTrophies;
        private int? _versusTrophies;
        private int? _versusBattleWins;

        public int ExpLevel { get => _expLevel ?? default; set => _expLevel = value; }

        public int Rank { get => _rank ?? default; set => _rank = value; }

        public int PreviousRank { get => _previousRank ?? default; set => _previousRank = value; }

        public int BuilderBaseTrophies { get => _builderBaseTrophies ?? default; set => _builderBaseTrophies = value; }

        public int VersusTrophies { get => _versusTrophies ?? default; set => _versusTrophies = value; }

        public int VersusBattleWins { get => _versusBattleWins ?? default; set => _versusBattleWins = value; }

        public PlayerRankingClan? Clan { get; set; }

        public BuilderBaseLeague BuilderBaseLeague { get; set; } = default!;
    }
}
