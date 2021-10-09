﻿using ClashOfClans.Api;
using ClashOfClans.Core;
using System;

namespace ClashOfClans
{
    /// <summary>
    /// Provides the client class for accessing information about clans, locations, leagues
    /// players and labels from Supercell's Clash of Clans service.
    /// </summary>
    public class ClashOfClansClient : IClashOfClans
    {
        private readonly ClashOfClansOptionsInternal _options;

        /// <summary>
        /// Initializes a new instance of the Clash of Clans API
        /// </summary>
        /// <param name="tokens">Your personal API key(s)</param>
        public ClashOfClansClient(params string[] tokens)
        {
            TokenValidator.Validate(tokens);

            _options = new ClashOfClansOptionsInternal(tokens);
            var gameData = new GameData(_options);

            Clans = new Clans(gameData);
            Locations = new Locations(gameData);
            Leagues = new Leagues(gameData);
            Players = new Players(gameData);
            Labels = new Labels(gameData);
            GoldPass = new GoldPass(gameData);
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
                _options.ThrottleRequests = new ThrottleRequestsPerSecond(
                    _options.MaxRequestsPerSecond,
                    _options.Tokens.Count);
            }
        }

        public IClans Clans { get; }

        public ILocations Locations { get; }

        public ILeagues Leagues { get; }

        public IPlayers Players { get; }

        public ILabels Labels { get; }

        public IGoldPass GoldPass { get; }
    }
}
