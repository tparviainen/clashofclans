using System.Linq;

namespace ClashOfClans.Models
{
    public partial class LocationList
    {
        public Location this[string name]
        {
            get => Items?.SingleOrDefault(l => l.Name == name);
        }
    }
}
