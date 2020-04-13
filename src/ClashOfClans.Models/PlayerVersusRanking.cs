namespace ClashOfClans.Models
{
    public class PlayerVersusRanking : Identity
    {
        public int? ExpLevel { get; set; }

        public int? Rank { get; set; }

        public int? PreviousRank { get; set; }

        public int? VersusTrophies { get; set; }

        public int? VersusBattleWins { get; set; }

        public PlayerRankingClan Clan { get; set; }
    }
}
