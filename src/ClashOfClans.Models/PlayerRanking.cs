namespace ClashOfClans.Models
{
    public class PlayerRanking : Identity
    {
        private int? _expLevel;
        private int? _trophies;
        private int? _attackWins;
        private int? _defenseWins;
        private int? _rank;

        public int ExpLevel { get => _expLevel ?? default; set => _expLevel = value; }

        public int Trophies { get => _trophies ?? default; set => _trophies = value; }

        public int AttackWins { get => _attackWins ?? default; set => _attackWins = value; }

        public int DefenseWins { get => _defenseWins ?? default; set => _defenseWins = value; }

        public int Rank { get => _rank ?? default; set => _rank = value; }

        public int? PreviousRank { get; set; }

        public PlayerRankingClan? Clan { get; set; }

        public League? League { get; set; }
    }
}
