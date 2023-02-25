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
        /// <param name="query">Optional query parameters</param>
        /// <exception cref="Core.ClashOfClansException">Communication error with the backend API</exception>
        /// <exception cref="System.ArgumentException">Argument is invalid</exception>
        /// <returns>Location list</returns>
        Task<QueryResult<LocationList>> GetLocationsAsync(Query? query = default);

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
        /// <param name="query">Optional query parameters</param>
        /// <exception cref="Core.ClashOfClansException">Communication error with the backend API</exception>
        /// <exception cref="System.ArgumentException">Argument is invalid</exception>
        /// <returns>Clan ranking list</returns>
        Task<QueryResult<ClanRankingList>> GetClanRankingAsync(int? locationId, Query? query = default);

        /// <summary>
        /// Get player rankings for a specific location
        /// </summary>
        /// <param name="locationId">Identifier of the location to retrieve</param>
        /// <param name="query">Optional query parameters</param>
        /// <exception cref="Core.ClashOfClansException">Communication error with the backend API</exception>
        /// <exception cref="System.ArgumentException">Argument is invalid</exception>
        /// <returns>Player ranking list</returns>
        Task<QueryResult<PlayerRankingList>> GetPlayerRankingAsync(int? locationId, Query? query = default);

        /// <summary>
        /// Get clan versus rankings for a specific location
        /// </summary>
        /// <param name="locationId">Identifier of the location to retrieve</param>
        /// <param name="query">Optional query parameters</param>
        /// <exception cref="Core.ClashOfClansException">Communication error with the backend API</exception>
        /// <exception cref="System.ArgumentException">Argument is invalid</exception>
        /// <returns>Clan ranking list</returns>
        Task<QueryResult<ClanVersusRankingList>> GetClanVersusRankingAsync(int? locationId, Query? query = default);

        /// <summary>
        /// Get player versus rankings for a specific location
        /// </summary>
        /// <param name="locationId">Identifier of the location to retrieve</param>
        /// <param name="query">Optional query parameters</param>
        /// <exception cref="Core.ClashOfClansException">Communication error with the backend API</exception>
        /// <exception cref="System.ArgumentException">Argument is invalid</exception>
        /// <returns>Player versus ranking list</returns>
        Task<QueryResult<PlayerVersusRankingList>> GetPlayerVersusRankingAsync(int? locationId, Query? query = default);

        /// <summary>
        /// Get capital rankings for a specific location
        /// </summary>
        /// <param name="locationId">Identifier of the location to retrieve</param>
        /// <param name="query">Optional query parameters</param>
        /// <exception cref="Core.ClashOfClansException">Communication error with the backend API</exception>
        /// <exception cref="System.ArgumentException">Argument is invalid</exception>
        /// <returns>Clan capital ranking list</returns>
        Task<QueryResult<ClanCapitalRankingList>> GetClanCapitalRankingAsync(int? locationId, Query? query = default);
    }
}
