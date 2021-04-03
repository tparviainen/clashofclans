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
        Task<Player> GetPlayerAsync(string playerTag);

        /// <summary>
        /// Verify player API token that can be found from the game settings.
        /// </summary>
        /// <param name="playerTag">Tag of the player</param>
        /// <param name="playerApiToken">Player API token</param>
        /// <returns></returns>
        Task<VerifyTokenResponse> VerifyTokenAsync(string playerTag, string playerApiToken);
    }
}
