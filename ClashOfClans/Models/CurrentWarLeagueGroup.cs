namespace ClashOfClans.Models
{
    public class CurrentWarLeagueGroup
    {
        public string State;

        public string Season;

        public InlineModel[] Clans;

        public InlineModel0[] Rounds;

        public override string ToString()
        {
            return $"CurrentWarLeagueGroup: State '{State}', Season '{Season}'";
        }
    }
}
