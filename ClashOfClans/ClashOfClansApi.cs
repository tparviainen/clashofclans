using ClashOfClans.Api;
using ClashOfClans.Core;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ClashOfClans.Tests")]
namespace ClashOfClans
{
    public class ClashOfClansApi
    {
        public ClashOfClansApi(string token, int maxRequestsPerSecond = 10)
        {
            var throttleRequests = new ThrottleRequestsPerSecond(maxRequestsPerSecond);

            Clans = new Clans(token, throttleRequests);
            Locations = new Locations(token, throttleRequests);
            Leagues = new Leagues(token, throttleRequests);
            Players = new Players(token, throttleRequests);
        }

        public IClans Clans { get; }
        public ILocations Locations { get; }
        public ILeagues Leagues { get; }
        public IPlayers Players { get; }
    }
}
