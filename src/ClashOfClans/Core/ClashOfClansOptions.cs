using System.Collections.Generic;

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
        /// The default name of the config section in appsettings.json file
        /// </summary>
        public const string ClashOfClans = "ClashOfClans";

        /// <summary>
        /// Your personal API key(s) for Supercell REST API
        /// </summary>
        public IReadOnlyList<string> Tokens { get; }

        /// <summary>
        /// Throttling limit for API requests per token. Default 10 API requests per second.
        /// </summary>
        public int MaxRequestsPerSecond { get; set; } = 10;

        /// <summary>
        /// Logger for diagnostics messages
        /// </summary>
        public IClashOfClansLogger? Logger { get; set; }
    }

    public class ClashOfClansOptionsV2 : ClashOfClansOptions
    {
        public ClashOfClansOptionsV2() : base(new List<string>())
        {
            Tokens = new List<string>();
        }

        new public List<string> Tokens { get; }
    }
}
