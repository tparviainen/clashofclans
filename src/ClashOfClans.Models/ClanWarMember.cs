namespace ClashOfClans.Models
{
    public class ClanWarMember : Identity
    {
        private int? _townhallLevel;
        private int? _mapPosition;
        private int? _opponentAttacks;

        public int TownhallLevel { get => _townhallLevel ?? default; set => _townhallLevel = value; }

        public int MapPosition { get => _mapPosition ?? default; set => _mapPosition = value; }

        public ClanWarAttackList? Attacks { get; set; }

        public int OpponentAttacks { get => _opponentAttacks ?? default; set => _opponentAttacks = value; }

        public ClanWarAttack? BestOpponentAttack { get; set; }
    }
}
