namespace ClashOfClans.Core
{
    internal class ClashOfClansOptionsInternal : ClashOfClansOptions
    {
        public IThrottleRequests ThrottleRequests;

        public ClashOfClansOptionsInternal(string token) : base(token)
        {
            ThrottleRequests = new ThrottleRequestsPerSecond(MaxRequestsPerSecond);
        }
    }
}
