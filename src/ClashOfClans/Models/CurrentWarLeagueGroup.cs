namespace ClashOfClans.Models
{
    public class CurrentWarLeagueGroup
    {
        public State? State { get; set; }

        public string Season { get; set; }

        public InlineModel[] Clans { get; set; }

        public InlineModel0[] Rounds { get; set; }

        public override string ToString()
        {
            return $"CurrentWarLeagueGroup: State '{State}', Season '{Season}'";
        }
    }
}
