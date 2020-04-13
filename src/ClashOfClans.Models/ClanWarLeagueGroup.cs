namespace ClashOfClans.Models
{
    public class ClanWarLeagueGroup
    {
        public State? State { get; set; }

        public string Season { get; set; }

        public ClanWarLeagueClanList Clans { get; set; }

        public ClanWarLeagueRoundList Rounds { get; set; }
    }
}
