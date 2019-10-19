using System.Collections.Generic;

namespace ClashOfClans.Models
{
    public partial class LeagueList : Queryable
    {
        public List<League> Items { get; set; }
    }
}
