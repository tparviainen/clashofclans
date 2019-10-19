using ClashOfClans.Models;
using ClashOfClans.Search;
using System.Threading.Tasks;

namespace ClashOfClans
{
    /// <summary>
    /// Access global and local rankings
    /// </summary>
    public interface ILocations
    {
        /// <summary>
        /// List locations
        /// </summary>
        /// <param name="query">Query parameters</param>
        /// <exception cref="Core.ClashOfClansException">Communication error with the backend API</exception>
        /// <exception cref="System.ArgumentException">Argument is invalid</exception>
        /// <returns>Location list</returns>
        Task<LocationList> GetLocationsAsync(Query query = null);

        /// <summary>
        /// Get location information
        /// </summary>
        /// <param name="locationId">Identifier of the location to retrieve</param>
        /// <exception cref="Core.ClashOfClansException">Communication error with the backend API</exception>
        /// <exception cref="System.ArgumentException">Argument is invalid</exception>
        /// <returns>Requested location</returns>
        Task<Location> GetLocationAsync(int? locationId);

        /// <summary>
        /// Get clan rankings for a specific location
        /// </summary>
        /// <param name="locationId">Identifier of the location to retrieve</param>
        /// <param name="query">Query parameters</param>
        /// <exception cref="Core.ClashOfClansException">Communication error with the backend API</exception>
        /// <exception cref="System.ArgumentException">Argument is invalid</exception>
        /// <returns>Clan ranking list</returns>
        Task<ClanRankingList> GetClanRankingAsync(int? locationId, Query query = null);

        /// <summary>
        /// Get player rankings for a specific location
        /// </summary>
        /// <param name="locationId">Identifier of the location to retrieve</param>
        /// <param name="query">Query parameters</param>
        /// <exception cref="Core.ClashOfClansException">Communication error with the backend API</exception>
        /// <exception cref="System.ArgumentException">Argument is invalid</exception>
        /// <returns>Player ranking list</returns>
        Task<PlayerRankingList> GetPlayerRankingAsync(int? locationId, Query query = null);

        /// <summary>
        /// Get clan versus rankings for a specific location
        /// </summary>
        /// <param name="locationId">Identifier of the location to retrieve</param>
        /// <param name="query">Query parameters</param>
        /// <exception cref="Core.ClashOfClansException">Communication error with the backend API</exception>
        /// <exception cref="System.ArgumentException">Argument is invalid</exception>
        /// <returns>Clan ranking list</returns>
        Task<ClanVersusRankingList> GetClanVersusRankingAsync(int? locationId, Query query = null);

        /// <summary>
        /// Get player versus rankings for a specific location
        /// </summary>
        /// <param name="locationId">Identifier of the location to retrieve</param>
        /// <param name="query">Query parameters</param>
        /// <exception cref="Core.ClashOfClansException">Communication error with the backend API</exception>
        /// <exception cref="System.ArgumentException">Argument is invalid</exception>
        /// <returns>Player versus ranking list</returns>
        Task<PlayerVersusRankingList> GetPlayerVersusRankingAsync(int? locationId, Query query = null);
    }
}
