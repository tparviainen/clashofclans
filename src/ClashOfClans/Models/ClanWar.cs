namespace ClashOfClans.Models
{
    public class ClanWar : WarBase
    {
        public WarClan Clan { get; set; }

        public WarClan Opponent { get; set; }
    }
}
