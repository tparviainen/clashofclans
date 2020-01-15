namespace ClashOfClans
{
    /// <summary>
    /// The Clash of Clans API provides near real­time access to game related data.
    /// </summary>
    public interface IClashOfClans
    {
        /// <summary>
        /// Access clan specific information
        /// </summary>
        IClans Clans { get; }

        /// <summary>
        /// Access global and local rankings
        /// </summary>
        ILocations Locations { get; }

        /// <summary>
        /// Access league information
        /// </summary>
        ILeagues Leagues { get; }

        /// <summary>
        /// Access player specific information
        /// </summary>
        IPlayers Players { get; }

        /// <summary>
        /// Access labels
        /// </summary>
        ILabels Labels { get; }
    }
}
