using ClashOfClans.Validation;

namespace ClashOfClans.Core
{
    internal class ClashOfClansOptionsInternal : ClashOfClansOptions
    {
        public IThrottleRequests ThrottleRequests;
        public readonly Validator Validator;

        public ClashOfClansOptionsInternal(string token) : base(token)
        {
            Validator = new Validator();
            ThrottleRequests = new ThrottleRequestsPerSecond(MaxRequestsPerSecond);

            Validator.ValidateToken(token);
        }
    }
}
