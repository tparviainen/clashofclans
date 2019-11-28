namespace ClashOfClans.Core
{
    /// <summary>
    /// Provides programmatic configuration for the Clash of Clans API
    /// </summary>
    public abstract class ClashOfClansOptions
    {
        protected ClashOfClansOptions(string token)
        {
            Token = token;
        }

        /// <summary>
        /// Your personal API key for Supercell REST API
        /// </summary>
        public string Token { get; }

        /// <summary>
        /// Throttling limit for API requests, default 10 API requests per second
        /// </summary>
        public int MaxRequestsPerSecond { get; set; } = 10;

        /// <summary>
        /// Logger for diagnostics messages
        /// </summary>
        public IClashOfClansLogger Logger { get; set; }
    }
}
