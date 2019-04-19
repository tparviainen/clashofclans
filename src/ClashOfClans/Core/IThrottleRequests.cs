using System.Threading.Tasks;

namespace ClashOfClans.Core
{
    internal interface IThrottleRequests
    {
        /// <summary>
        /// Blocks the execution of the current thread if throttling limit reached
        /// </summary>
        Task WaitAsync();
    }
}
