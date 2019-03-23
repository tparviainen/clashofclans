namespace ClashOfClans.Models
{
    public class SeasonPlayerRanking : Identity
    {
        public int? ExpLevel;

        public int? Trophies;

        public int? AttackWins;

        public int? DefenseWins;

        public int? Rank;

        public InlineModel1 Clan;
    }
}