using ClashOfClans.Models;
using ClashOfClans.Search;
using System.Threading.Tasks;

namespace ClashOfClans
{
    public interface ILabels
    {
        Task<ItemList<LabelList>> GetClanLabelsAsync(Query query = null);
        Task<ItemList<LabelList>> GetPlayerLabelsAsync(Query query = null);
    }
}
