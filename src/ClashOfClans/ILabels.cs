using ClashOfClans.Models;
using ClashOfClans.Search;
using System.Threading.Tasks;

namespace ClashOfClans
{
    public interface ILabels
    {
        Task<QueryResult<LabelList>> GetClanLabelsAsync(Query query = null);

        Task<QueryResult<LabelList>> GetPlayerLabelsAsync(Query query = null);
    }
}
