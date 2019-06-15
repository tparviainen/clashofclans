using ClashOfClans.Models;
using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ClashOfClans.Core
{
    /// <summary>
    /// Represents errors that occur when communicating with the official Clash of Clans API
    /// </summary>
    [Serializable]
    public class ClashOfClansException : Exception
    {
        /// <summary>
        /// The error that caused the exception to occur.
        /// </summary>
        public Error Error { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClashOfClansException"/> class.
        /// </summary>
        /// <param name="error">API endpoint error</param>
        public ClashOfClansException(Error error)
        {
            Error = error;
        }

        protected ClashOfClansException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Error = info.GetValue(nameof(Error), typeof(Error)) as Error;
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue(nameof(Error), Error);

            base.GetObjectData(info, context);
        }
    }
}
