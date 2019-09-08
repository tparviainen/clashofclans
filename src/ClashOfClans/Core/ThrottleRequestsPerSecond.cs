using System;
using System.Threading.Tasks;

namespace ClashOfClans.Core
{
    internal class ThrottleRequestsPerSecond : IThrottleRequests
    {
        private DateTime _nextAllowedApiCallTime;
        private readonly int _delayBetweenApiCalls;
        private readonly object throttlingLock = new object();

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
            var continuationTime = ContinuationTime();
            var millisecondsDelay = (int)(continuationTime - DateTime.Now).TotalMilliseconds;

            if (millisecondsDelay > 0)
            {
                await Task.Delay(millisecondsDelay);
            }
        }

        /// <summary>
        /// Returns the continuation time when the task can continue execution
        /// </summary>
        /// <returns></returns>
        private DateTime ContinuationTime()
        {
            lock (throttlingLock)
            {
                var now = DateTime.Now;
                var continuationTime = _nextAllowedApiCallTime;

                if (continuationTime < now)
                {
                    continuationTime = now;
                }

                _nextAllowedApiCallTime = continuationTime.AddMilliseconds(_delayBetweenApiCalls);

                return continuationTime;
            }
        }
    }
}
