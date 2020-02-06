using System;
using System.Threading.Tasks;

namespace ClashOfClans.Core
{
    internal class ThrottleRequestsPerSecond : IThrottleRequests
    {
        private DateTime _nextAllowedApiCallTime;
        private readonly long _delayBetweenApiCalls;
        private readonly object _throttlingLock = new object();

        public ThrottleRequestsPerSecond(int maxRequestsPerSecond, int tokens = 1)
        {
            if (maxRequestsPerSecond <= 0)
            {
                throw new ArgumentException(nameof(maxRequestsPerSecond));
            }

            _nextAllowedApiCallTime = DateTime.Now;
            _delayBetweenApiCalls = TimeSpan.TicksPerSecond / (maxRequestsPerSecond * tokens);
        }

        public Task WaitAsync()
        {
            var continuationTime = ContinuationTime();
            var millisecondsDelay = (int)(continuationTime - DateTime.Now).TotalMilliseconds;

            if (millisecondsDelay > 0)
            {
                return Task.Delay(millisecondsDelay);
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Returns the continuation time when the task can continue execution
        /// </summary>
        private DateTime ContinuationTime()
        {
            lock (_throttlingLock)
            {
                var now = DateTime.Now;
                var continuationTime = _nextAllowedApiCallTime;

                if (continuationTime < now)
                {
                    continuationTime = now;
                }

                _nextAllowedApiCallTime = continuationTime.AddTicks(_delayBetweenApiCalls);

                return continuationTime;
            }
        }
    }
}
