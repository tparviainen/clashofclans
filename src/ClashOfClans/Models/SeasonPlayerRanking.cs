namespace ClashOfClans.Models
{
    public class SeasonPlayerRanking : Identity
    {
        public int? ExpLevel { get; set; }

        public int? Trophies { get; set; }

        public int? AttackWins { get; set; }

        public int? DefenseWins { get; set; }

        public int? Rank { get; set; }

        public InlineModel1 Clan { get; set; }
    }
}
