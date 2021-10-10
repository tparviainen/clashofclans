namespace ClashOfClans.DependencyInjection
{
    internal class ClashOfClansDIClient : IClashOfClans
    {
        public ClashOfClansDIClient(IClans clans,
                                    ILocations locations,
                                    ILeagues leagues,
                                    IPlayers players,
                                    ILabels labels,
                                    IGoldPass goldPass)
        {
            Clans = clans;
            Locations = locations;
            Leagues = leagues;
            Players = players;
            Labels = labels;
            GoldPass = goldPass;
        }

        public IClans Clans { get; }

        public ILocations Locations { get; }

        public ILeagues Leagues { get; }

        public IPlayers Players { get; }

        public ILabels Labels { get; }

        public IGoldPass GoldPass { get; }
    }
}
