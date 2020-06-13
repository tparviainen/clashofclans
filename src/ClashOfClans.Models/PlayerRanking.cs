namespace ClashOfClans.Models
{
    public class PlayerRanking : Identity
    {
        public int? ExpLevel { get; set; }

        public int? Trophies { get; set; }

        public int? AttackWins { get; set; }

        public int? DefenseWins { get; set; }

        public int? Rank { get; set; }

        public int? PreviousRank { get; set; }

        public PlayerRankingClan? Clan { get; set; }

        public League? League { get; set; }
    }
}
