using System;
using System.Collections.Generic;
using System.Linq;

namespace ClashOfClans.Core
{
    /// <summary>
    /// Provides programmatic configuration for the Clash of Clans API
    /// </summary>
    public abstract class ClashOfClansOptions
    {
        protected ClashOfClansOptions(IReadOnlyList<string> tokens)
        {
            Tokens = tokens;
        }

        /// <summary>
        /// Your personal API key(s) for Supercell REST API
        /// </summary>
        public IReadOnlyList<string> Tokens { get; }

        /// <summary>
        /// Your personal API key for Supercell REST API
        /// </summary>
        [Obsolete("Use Tokens instead.")]
        public string Token => Tokens.FirstOrDefault();

        /// <summary>
        /// Throttling limit for API requests per token. Default 10 API requests per second.
        /// </summary>
        public int MaxRequestsPerSecond { get; set; } = 10;

        /// <summary>
        /// Logger for diagnostics messages
        /// </summary>
        public IClashOfClansLogger Logger { get; set; }
    }
}
