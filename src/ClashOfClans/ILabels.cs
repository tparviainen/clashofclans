using ClashOfClans.Models;
using ClashOfClans.Search;
using System.Threading.Tasks;

namespace ClashOfClans
{
    public interface ILabels
    {
        /// <summary>
        /// List clan labels
        /// </summary>
        /// <param name="query">Query parameters</param>
        /// <returns>Clan label list</returns>
        Task<QueryResult<LabelList>> GetClanLabelsAsync(Query query = null);

        /// <summary>
        /// List player labels
        /// </summary>
        /// <param name="query">Query parameters</param>
        /// <returns>Player label list</returns>
        Task<QueryResult<LabelList>> GetPlayerLabelsAsync(Query query = null);
    }
}
