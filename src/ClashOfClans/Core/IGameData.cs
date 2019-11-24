using System.Threading.Tasks;

namespace ClashOfClans.Core
{
    /// <summary>
    /// Provides an interface to read game data
    /// </summary>
    internal interface IGameData
    {
        Task<T> RequestAsync<T>(AutoValidatedRequest request) where T : class;
    }
}
