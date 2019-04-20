using ClashOfClans.Api;
using ClashOfClans.Core;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ClashOfClans.Tests")]
namespace ClashOfClans
{
    /// <summary>
    /// Clash of Clans API that provides access to information about
    /// clans, locations, leagues and players.
    /// </summary>
    public class ClashOfClansApi
    {
        /// <summary>
        /// Initializes a new instance of the Clash of Clans API
        /// </summary>
        /// <param name="token">Your personal API key</param>
        /// <param name="maxRequestsPerSecond">Throttling limit for API requests</param>
        public ClashOfClansApi(string token, int maxRequestsPerSecond = 10)
        {
            var throttleRequests = new ThrottleRequestsPerSecond(maxRequestsPerSecond);

            Clans = new Clans(token, throttleRequests);
            Locations = new Locations(token, throttleRequests);
            Leagues = new Leagues(token, throttleRequests);
            Players = new Players(token, throttleRequests);
        }

        /// <summary>
        /// Interface for clans
        /// </summary>
        public IClans Clans { get; }

        /// <summary>
        /// Interface for locations
        /// </summary>
        public ILocations Locations { get; }

        /// <summary>
        /// Interface for leagues
        /// </summary>
        public ILeagues Leagues { get; }

        /// <summary>
        /// Interface for players
        /// </summary>
        public IPlayers Players { get; }
    }
}
