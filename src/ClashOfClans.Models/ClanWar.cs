namespace ClashOfClans.Models
{
    public class ClanWar : WarBase
    {
        public WarClan Clan { get; set; } = default!;

        public WarClan Opponent { get; set; } = default!;
    }
}
