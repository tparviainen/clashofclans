using System.Collections.Generic;

namespace ClashOfClans.Models
{
    public partial class LocationList : Queryable
    {
        public List<Location> Items { get; set; }
    }
}
