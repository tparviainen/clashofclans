using ClashOfClans.Models;
using ClashOfClans.Search;
using System.Threading.Tasks;

namespace ClashOfClans
{
    /// <summary>
    /// Interface for locations and clan/player ranking in a location
    /// </summary>
    public interface ILocations
    {
        /// <summary>
        /// List locations
        /// </summary>
        /// <param name="query">Query parameters</param>
        /// <returns></returns>
        Task<LocationList> GetAsync(Query query = null);

        /// <summary>
        /// Get location information
        /// </summary>
        /// <param name="locationId">Identifier of the location to retrieve</param>
        /// <returns></returns>
        Task<Location> GetAsync(int? locationId);

        /// <summary>
        /// Get clan rankings for a specific location
        /// </summary>
        /// <param name="locationId">Identifier of the location to retrieve</param>
        /// <param name="query">Query parameters</param>
        /// <returns></returns>
        Task<ClanRankingList> GetRankingsClansAsync(int? locationId, Query query = null);

        /// <summary>
        /// Get player rankings for a specific location
        /// </summary>
        /// <param name="locationId">Identifier of the location to retrieve</param>
        /// <param name="query">Query parameters</param>
        /// <returns></returns>
        Task<PlayerRankingList> GetRankingsPlayersAsync(int? locationId, Query query = null);

        /// <summary>
        /// Get clan versus rankings for a specific location
        /// </summary>
        /// <param name="locationId">Identifier of the location to retrieve</param>
        /// <param name="query">Query parameters</param>
        /// <returns></returns>
        Task<ClanRankingList> GetRankingsClansVersusAsync(int? locationId, Query query = null);

        /// <summary>
        /// Get player versus rankings for a specific location
        /// </summary>
        /// <param name="locationId">Identifier of the location to retrieve</param>
        /// <param name="query">Query parameters</param>
        /// <returns></returns>
        Task<PlayerVersusRankingList> GetRankingsPlayersVersusAsync(int? locationId, Query query = null);
    }
}
