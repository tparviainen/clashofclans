namespace ClashOfClans.Models
{
    public class ClanWarMember : Identity
    {
        public string TownhallLevel { get; set; }

        public int? MapPosition { get; set; }

        public ClanWarAttackList[] Attacks { get; set; }

        public int? OpponentAttacks { get; set; }

        public ClanWarAttack BestOpponentAttack { get; set; }
    }
}
