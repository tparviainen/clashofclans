namespace ClashOfClans.Models
{
    public class ClanWarLeagueClanMember : Identity
    {
        private int? _townHallLevel;

        public int TownHallLevel { get => _townHallLevel ?? default; set => _townHallLevel = value; }
    }
}
