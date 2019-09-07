using System.Threading.Tasks;

namespace ClashOfClans.Core
{
    /// <summary>
    /// Provides an interface to communicate with the API endpoint
    /// </summary>
    internal interface IApiEndpoint
    {
        Task<T> RequestAsync<T>(string uri) where T : class;
    }
}
