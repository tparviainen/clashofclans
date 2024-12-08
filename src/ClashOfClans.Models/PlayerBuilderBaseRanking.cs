namespace ClashOfClans.Models
{
    public class PlayerBuilderBaseRanking : Identity
    {
        public int ExpLevel { get; set; }

        public int Rank { get; set; }

        public int PreviousRank { get; set; }

        public int BuilderBaseTrophies { get; set; }

        public PlayerRankingClan? Clan { get; set; }

        public BuilderBaseLeague BuilderBaseLeague { get; set; } = default!;
    }
}
