using ClashOfClans.Models;
using System;

namespace ClashOfClans.Core
{
    /// <summary>
    /// Represents errors that occur when communicating with the official Clash of Clans API
    /// </summary>
    public class ClashOfClansException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClashOfClansException"/> class.
        /// </summary>
        /// <param name="error">API endpoint error</param>
        public ClashOfClansException(Error error)
        {
            Error = error;
        }

        /// <summary>
        /// The error that caused the exception to occur.
        /// </summary>
        public Error Error { get; }
    }
}
