using ClashOfClans.Api;
using ClashOfClans.Core;
using System;
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
        private readonly ClashOfClansOptionsInternal _options;

        /// <summary>
        /// Initializes a new instance of the Clash of Clans API
        /// </summary>
        /// <param name="token">Your personal API key</param>
        public ClashOfClansApi(string token)
        {
            _options = new ClashOfClansOptionsInternal(token);

            Clans = new Clans(_options);
            Locations = new Locations(_options);
            Leagues = new Leagues(_options);
            Players = new Players(_options);
        }

        /// <summary>
        /// Registers an action used to configure particular type of options
        /// </summary>
        /// <param name="configure">An action delegate to configure the provided options</param>
        public void Configure(Action<ClashOfClansOptions> configure)
        {
            var maxRequestsPerSecond = _options.MaxRequestsPerSecond;

            configure(_options);

            if (_options.MaxRequestsPerSecond != maxRequestsPerSecond)
            {
                _options.ThrottleRequests = new ThrottleRequestsPerSecond(_options.MaxRequestsPerSecond);
            }
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
