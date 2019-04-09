using ClashOfClans.Models;
using ClashOfClans.Search;
using System.Threading.Tasks;

namespace ClashOfClans
{
    public interface IClans
    {
        /// <summary>
        /// Search clans
        /// </summary>
        /// <param name="query">Query parameters</param>
        /// <returns></returns>
        Task<SearchResult> GetAsync(QueryClans query);

        /// <summary>
        /// Get clan information
        /// </summary>
        /// <param name="clanTag">Tag of the clan to retrieve</param>
        /// <returns></returns>
        Task<Clan> GetAsync(string clanTag);

        /// <summary>
        /// List clan members
        /// </summary>
        /// <param name="clanTag">Tag of the clan whose members to retrieve</param>
        /// <param name="query">Query parameters</param>
        /// <returns></returns>
        Task<ClanMemberList> GetMembersAsync(string clanTag, Query query = null);

        /// <summary>
        /// Retrieve clan's clan war log
        /// </summary>
        /// <param name="clanTag">Tag of the clan whose war log to retrieve</param>
        /// <param name="query">Query parameters</param>
        /// <returns></returns>
        Task<WarLog> GetWarLogAsync(string clanTag, Query query = null);

        /// <summary>
        /// Retrieve information about clan's current clan war
        /// </summary>
        /// <param name="clanTag">Tag of the clan whose current clan war information to retrieve</param>
        /// <returns></returns>
        Task<CurrentWar> GetCurrentWarAsync(string clanTag);

        /// <summary>
        /// Retrieve information about clan's current clan war league group
        /// </summary>
        /// <param name="clanTag">Tag of the clan whose current clan war league group to retrieve</param>
        /// <returns></returns>
        Task<CurrentWarLeagueGroup> GetCurrentWarLeagueGroupAsync(string clanTag);

        /// <summary>
        /// Retrieve information about a clan war league war
        /// </summary>
        /// <param name="warTag">Tag of the war whose information to retrieve</param>
        /// <returns></returns>
        Task<ClanWarLeagueWar> GetClanWarLeaguesWarsAsync(string warTag);
    }
}
