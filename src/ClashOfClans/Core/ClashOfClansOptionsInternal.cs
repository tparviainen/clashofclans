using ClashOfClans.Validation;

namespace ClashOfClans.Core
{
    internal class ClashOfClansOptionsInternal : ClashOfClansOptions
    {
        internal IThrottleRequests _throttleRequests;
        internal readonly Validator _validator;

        public ClashOfClansOptionsInternal(string token) : base(token)
        {
            _validator = new Validator();
            _throttleRequests = new ThrottleRequestsPerSecond(MaxRequestsPerSecond);

            _validator.ValidateToken(token);
        }
    }
}
