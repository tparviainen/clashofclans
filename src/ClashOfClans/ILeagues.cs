using ClashOfClans.Models;
using ClashOfClans.Search;
using System.Threading.Tasks;

namespace ClashOfClans
{
    /// <summary>
    /// Access league information
    /// </summary>
    public interface ILeagues
    {
        /// <summary>
        /// List leagues
        /// </summary>
        /// <param name="query">Query parameters</param>
        /// <exception cref="Core.ClashOfClansException">Communication error with the backend API</exception>
        /// <exception cref="System.ArgumentException">Argument is invalid</exception>
        /// <returns>League list</returns>
        Task<QueryResult<LeagueList>> GetLeaguesAsync(Query query = null);

        /// <summary>
        /// Get league information
        /// </summary>
        /// <param name="leagueId">Identifier of the league to retrieve</param>
        /// <exception cref="Core.ClashOfClansException">Communication error with the backend API</exception>
        /// <exception cref="System.ArgumentException">Argument is invalid</exception>
        /// <returns>Requested league</returns>
        Task<League> GetLeagueAsync(int? leagueId);

        /// <summary>
        /// Get league seasons. Note that league season information is available only for Legend League.
        /// </summary>
        /// <param name="leagueId">Identifier of the league whose seasons retrieve</param>
        /// <param name="query">Query parameters</param>
        /// <exception cref="Core.ClashOfClansException">Communication error with the backend API</exception>
        /// <exception cref="System.ArgumentException">Argument is invalid</exception>
        /// <returns>League season list</returns>
        Task<QueryResult<LeagueSeasonList>> GetLeagueSeasonsAsync(int? leagueId, Query query = null);

        /// <summary>
        /// Get league season rankings. Note that league season information is available only for Legend League.
        /// </summary>
        /// <param name="leagueId">Identifier of the league whose season rankings retrieve</param>
        /// <param name="seasonId">Identifier of the season whose rankings retrieve</param>
        /// <param name="query">Query parameters</param>
        /// <exception cref="Core.ClashOfClansException">Communication error with the backend API</exception>
        /// <exception cref="System.ArgumentException">Argument is invalid</exception>
        /// <returns>Season player ranking list</returns>
        Task<QueryResult<PlayerRankingList>> GetLeagueSeasonRankingsAsync(int? leagueId, string seasonId, Query query = null);
    }
}
