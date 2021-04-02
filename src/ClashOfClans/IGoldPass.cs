using ClashOfClans.Models;
using System.Threading.Tasks;

namespace ClashOfClans
{
    /// <summary>
    /// Access information about gold pass
    /// </summary>
    public interface IGoldPass
    {
        /// <summary>
        /// Get information about the current gold pass season
        /// </summary>
        /// <returns></returns>
        Task<GoldPassSeason> GetCurrentGoldPassSeasonAsync();
    }
}
