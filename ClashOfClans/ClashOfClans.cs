using ClashOfClans.Core;

namespace ClashOfClans
{
    public class ClashOfClans
    {
        public ClashOfClans(string token)
        {
            Clans = new Clans(token);
            Locations = new Locations(token);
            Leagues = new Leagues(token);
            Players = new Players(token);
        }

        public IClans Clans { get; }
        public ILocations Locations { get; }
        public ILeagues Leagues { get; }
        public IPlayers Players { get; }
    }
}
