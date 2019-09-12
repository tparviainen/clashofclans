using System.Threading.Tasks;

namespace ClashOfClans.Core
{
    /// <summary>
    /// Provides an interface to read game data
    /// </summary>
    internal interface IGameData
    {
        Task<T> RequestAsync<T>(string uri) where T : class;
    }
}
