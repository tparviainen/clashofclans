namespace ClashOfClans.Models
{
    public class PlayerRanking : Identity
    {
        public int? ExpLevel;

        public int? Trophies;

        public int? AttackWins;

        public int? DefenseWins;

        public int? Rank;

        public int? PreviousRank;

        public InlineModel1 Clan;

        public League League;
    }
}