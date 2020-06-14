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
        public ClientError Error { get; } = default!;

        public ClashOfClansException()
        {
        }

        public ClashOfClansException(string message)
            : base(message)
        {
        }

        public ClashOfClansException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClashOfClansException"/> class.
        /// </summary>
        /// <param name="error">API endpoint error</param>
        public ClashOfClansException(ClientError error)
        {
            Error = error;
        }

        protected ClashOfClansException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Error = (ClientError)info.GetValue(nameof(Error), typeof(ClientError))!;
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue(nameof(Error), Error);
        }
    }
}
