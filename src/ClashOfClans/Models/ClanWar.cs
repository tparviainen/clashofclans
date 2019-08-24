namespace ClashOfClans.Models
{
    public class ClanWar : WarBase
    {
        public WarClan Clan { get; set; }

        public WarClan Opponent { get; set; }

        public override string ToString()
        {
            return $"ClanWar: State '{State}', {Clan.Tag} vs {Opponent.Tag}";
        }
    }
}
