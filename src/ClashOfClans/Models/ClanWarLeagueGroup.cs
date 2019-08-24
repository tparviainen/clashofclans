namespace ClashOfClans.Models
{
    public class ClanWarLeagueGroup
    {
        public State? State { get; set; }

        public string Season { get; set; }

        public InlineModel[] Clans { get; set; }

        public InlineModel0[] Rounds { get; set; }

        public override string ToString()
        {
            return $"ClanWarLeagueGroup: State '{State}', Season '{Season}'";
        }
    }
}
