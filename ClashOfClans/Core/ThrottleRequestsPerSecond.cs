using System;
using System.Threading.Tasks;

namespace ClashOfClans.Core
{
    internal class ThrottleRequestsPerSecond : IThrottleRequests
    {
        private DateTime _nextAllowedApiCallTime;
        private readonly int _delayBetweenApiCalls;

        public ThrottleRequestsPerSecond(int maxRequestsPerSecond)
        {
            if (maxRequestsPerSecond <= 0)
            {
                throw new ArgumentException(nameof(maxRequestsPerSecond));
            }

            _nextAllowedApiCallTime = DateTime.Now;
            _delayBetweenApiCalls = 1000 / maxRequestsPerSecond;
        }

        public async Task WaitAsync()
        {
            var now = DateTime.Now;

            if (now < _nextAllowedApiCallTime)
            {
                var millisecondsDelay = (int)(_nextAllowedApiCallTime - now).TotalMilliseconds;
                await Task.Delay(millisecondsDelay);
            }

            _nextAllowedApiCallTime = DateTime.Now.AddMilliseconds(_delayBetweenApiCalls);
        }
    }
}
