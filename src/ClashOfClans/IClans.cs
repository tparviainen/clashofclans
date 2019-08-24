using ClashOfClans.Models;
using ClashOfClans.Search;
using System.Threading.Tasks;

namespace ClashOfClans
{
    /// <summary>
    /// Access clan specific information
    /// </summary>
    public interface IClans
    {
        /// <summary>
        /// Search clans
        /// </summary>
        /// <param name="query">Query parameters</param>
        /// <exception cref="Core.ClashOfClansException">Communication error with the backend API</exception>
        /// <exception cref="System.ArgumentException">Argument is invalid</exception>
        /// <returns>Clan(s) that match the query criteria</returns>
        Task<ClanList> GetAsync(QueryClans query);

        /// <summary>
        /// Get clan information
        /// </summary>
        /// <param name="clanTag">Tag of the clan to retrieve</param>
        /// <exception cref="Core.ClashOfClansException">Communication error with the backend API</exception>
        /// <exception cref="System.ArgumentException">Argument is invalid</exception>
        /// <returns>Requested clan</returns>
        Task<Clan> GetAsync(string clanTag);

        /// <summary>
        /// List clan members
        /// </summary>
        /// <param name="clanTag">Tag of the clan whose members to retrieve</param>
        /// <param name="query">Query parameters</param>
        /// <exception cref="Core.ClashOfClansException">Communication error with the backend API</exception>
        /// <exception cref="System.ArgumentException">Argument is invalid</exception>
        /// <returns>List of clan members</returns>
        Task<ClanMemberList> GetMembersAsync(string clanTag, Query query = null);

        /// <summary>
        /// Retrieve clan's clan war log
        /// </summary>
        /// <param name="clanTag">Tag of the clan whose war log to retrieve</param>
        /// <param name="query">Query parameters</param>
        /// <exception cref="Core.ClashOfClansException">Communication error with the backend API</exception>
        /// <exception cref="System.ArgumentException">Argument is invalid</exception>
        /// <returns>Clan's clan war log</returns>
        Task<WarLog> GetWarLogAsync(string clanTag, Query query = null);

        /// <summary>
        /// Retrieve information about clan's current clan war
        /// </summary>
        /// <param name="clanTag">Tag of the clan whose current clan war information to retrieve</param>
        /// <exception cref="Core.ClashOfClansException">Communication error with the backend API</exception>
        /// <exception cref="System.ArgumentException">Argument is invalid</exception>
        /// <returns>Current war data</returns>
        Task<CurrentWar> GetCurrentWarAsync(string clanTag);

        /// <summary>
        /// Retrieve information about clan's current clan war league group
        /// </summary>
        /// <param name="clanTag">Tag of the clan whose current clan war league group to retrieve</param>
        /// <exception cref="Core.ClashOfClansException">Communication error with the backend API</exception>
        /// <exception cref="System.ArgumentException">Argument is invalid</exception>
        /// <returns>Clan's current clan war league group</returns>
        Task<CurrentWarLeagueGroup> GetCurrentWarLeagueGroupAsync(string clanTag);

        /// <summary>
        /// Retrieve information about individual clan war league war
        /// </summary>
        /// <param name="warTag">Tag of the war whose information to retrieve</param>
        /// <exception cref="Core.ClashOfClansException">Communication error with the backend API</exception>
        /// <exception cref="System.ArgumentException">Argument is invalid</exception>
        /// <returns>Clan war league war data</returns>
        Task<ClanWarLeagueWar> GetClanWarLeaguesWarsAsync(string warTag);
    }
}
