using ClashOfClans.Models;
using ClashOfClans.Search;
using System.Threading.Tasks;

namespace ClashOfClans
{
    /// <summary>
    /// Access clan and player labels
    /// </summary>
    public interface ILabels
    {
        /// <summary>
        /// List clan labels
        /// </summary>
        /// <param name="query">Optional query parameters</param>
        /// <returns>Clan label list</returns>
        Task<QueryResult<LabelList>> GetClanLabelsAsync(Query? query = default);

        /// <summary>
        /// List player labels
        /// </summary>
        /// <param name="query">Optional query parameters</param>
        /// <returns>Player label list</returns>
        Task<QueryResult<LabelList>> GetPlayerLabelsAsync(Query? query = default);
    }
}
