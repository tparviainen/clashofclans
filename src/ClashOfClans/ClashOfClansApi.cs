﻿using ClashOfClans.Api;
using ClashOfClans.Core;
using ClashOfClans.Validation;
using System;

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
            var validator = new Validator();
            validator.ValidateToken(token);

            _options = new ClashOfClansOptionsInternal(token);
            var gameData = new GameData(_options);

            Clans = new Clans(gameData, validator);
            Locations = new Locations(gameData, validator);
            Leagues = new Leagues(gameData, validator);
            Players = new Players(gameData, validator);
        }

        /// <summary>
        /// Registers an action used to configure particular type of options
        /// </summary>
        /// <param name="configure">An action delegate to configure the provided options</param>
        public void Configure(Action<ClashOfClansOptions> configure)
        {
            var maxRequestsPerSecond = _options.MaxRequestsPerSecond;

            configure(_options);

            if (maxRequestsPerSecond != _options.MaxRequestsPerSecond)
            {
                _options.ThrottleRequests = new ThrottleRequestsPerSecond(_options.MaxRequestsPerSecond);
            }
        }

        /// <summary>
        /// Access clan specific information
        /// </summary>
        public IClans Clans { get; }

        /// <summary>
        /// Access global and local rankings
        /// </summary>
        public ILocations Locations { get; }

        /// <summary>
        /// Access league information
        /// </summary>
        public ILeagues Leagues { get; }

        /// <summary>
        /// Access player specific information
        /// </summary>
        public IPlayers Players { get; }
    }
}
