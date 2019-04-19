using ClashOfClans.Models;
using System.Threading.Tasks;

namespace ClashOfClans
{
    /// <summary>
    /// Interface for player related data
    /// </summary>
    public interface IPlayers
    {
        /// <summary>
        /// Get player information
        /// </summary>
        /// <param name="playerTag">Tag of the player to retrieve</param>
        /// <returns></returns>
        Task<PlayerDetail> GetAsync(string playerTag);
    }
}
