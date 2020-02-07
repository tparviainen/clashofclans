using System.Collections.Generic;

namespace ClashOfClans.Core
{
    internal class ClashOfClansOptionsInternal : ClashOfClansOptions
    {
        public IThrottleRequests ThrottleRequests;

        public ClashOfClansOptionsInternal(IReadOnlyList<string> tokens) : base(tokens)
        {
            ThrottleRequests = new ThrottleRequestsPerSecond(MaxRequestsPerSecond, tokens.Count);
        }
    }
}
