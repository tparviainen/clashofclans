using ClashOfClans.Models;
using System.Threading.Tasks;

namespace ClashOfClans
{
    /// <summary>
    /// Access player specific information
    /// </summary>
    public interface IPlayers
    {
        /// <summary>
        /// Get player information
        /// </summary>
        /// <param name="playerTag">Tag of the player to retrieve</param>
        /// <exception cref="Core.ClashOfClansException">Communication error with the backend API</exception>
        /// <exception cref="System.ArgumentException">Argument is invalid</exception>
        /// <returns>Requested player data</returns>
        Task<Player> GetAsync(string playerTag);
    }
}
