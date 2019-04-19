using ClashOfClans.Models;
using ClashOfClans.Search;
using System.Threading.Tasks;

namespace ClashOfClans
{
    public interface ILeagues
    {
        /// <summary>
        /// List leagues
        /// </summary>
        /// <param name="query">Query parameters</param>
        /// <returns></returns>
        Task<LeagueList> GetAsync(Query query = null);

        /// <summary>
        /// Get league information
        /// </summary>
        /// <param name="leagueId">Identifier of the league to retrieve</param>
        /// <returns></returns>
        Task<League> GetAsync(int? leagueId);

        /// <summary>
        /// Get league seasons
        /// </summary>
        /// <param name="leagueId">Identifier of the league whose seasons retrieve</param>
        /// <param name="query">Query parameters</param>
        /// <returns></returns>
        Task<LeagueSeasonList> GetSeasonsAsync(int? leagueId, Query query = null);

        /// <summary>
        /// Get league season rankings
        /// </summary>
        /// <param name="leagueId">Identifier of the league whose season rankings retrieve</param>
        /// <param name="seasonId">Identifier of the season whose rankings retrieve</param>
        /// <param name="query">Query parameters</param>
        /// <returns></returns>
        Task<SeasonPlayerRankingList> GetSeasonsAsync(int? leagueId, string seasonId, Query query = null);
    }
}
