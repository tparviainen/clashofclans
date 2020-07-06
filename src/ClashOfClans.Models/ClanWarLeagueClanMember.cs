namespace ClashOfClans.Models
{
    public class ClanWarLeagueClanMember : Identity
    {
        private int? townHallLevel;

        public int TownHallLevel { get => townHallLevel ?? default; set => townHallLevel = value; }
    }
}
