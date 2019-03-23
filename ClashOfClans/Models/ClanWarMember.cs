namespace ClashOfClans.Models
{
    public class ClanWarMember : Identity
    {
        public string TownhallLevel;

        public int? MapPosition;

        public ClanWarAttack[] Attacks;

        public int? OpponentAttacks;

        public ClanWarAttack BestOpponentAttack;
    }
}