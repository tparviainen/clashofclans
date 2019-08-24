namespace ClashOfClans.Models
{
    public class ClanWarLeagueGroup
    {
        public State? State { get; set; }

        public string Season { get; set; }

        public ClanWarLeagueClanList Clans { get; set; }

        public ClanWarLeagueRoundList Rounds { get; set; }

        public override string ToString()
        {
            return $"ClanWarLeagueGroup: State '{State}', Season '{Season}'";
        }
    }
}
