namespace ClashOfClans.Core
{
    /// <summary>
    /// Represents a type used to perform logging
    /// </summary>
    public interface IClashOfClansLogger
    {
        /// <summary>
        /// Writes a log entry
        /// </summary>
        /// <param name="message">Log message</param>
        void Log(string message);
    }
}
