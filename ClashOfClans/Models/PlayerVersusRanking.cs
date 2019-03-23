namespace ClashOfClans.Models
{
    public class PlayerVersusRanking : Identity
    {
        public int? ExpLevel;

        public int? Rank;

        public int? PreviousRank;

        public int? VersusTrophies;

        public int? VersusBattleWins;

        public InlineModel1 Clan;
    }
}