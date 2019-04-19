using System.Linq;

namespace ClashOfClans.Models
{
    public partial class LeagueList
    {
        public League this[string name]
        {
            get => Items?.SingleOrDefault(l => l.Name == name);
        }
    }
}
