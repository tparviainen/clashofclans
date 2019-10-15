using System.Collections.Generic;

namespace ClashOfClans.Models
{
    public class ClanList : Queryable
    {
        public List<Clan> Items { get; set; }
    }
}
