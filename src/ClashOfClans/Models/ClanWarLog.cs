using System.Collections.Generic;

namespace ClashOfClans.Models
{
    public class ClanWarLog : Queryable
    {
        public List<ClanWarLogEntry> Items { get; set; }
    }
}
