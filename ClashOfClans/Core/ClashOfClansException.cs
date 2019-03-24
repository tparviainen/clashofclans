using ClashOfClans.Models;
using System;

namespace ClashOfClans.Core
{
    public class ClashOfClansException : Exception
    {
        public ClashOfClansException(Error error)
        {
            Error = error;
        }

        public Error Error { get; }
    }
}
