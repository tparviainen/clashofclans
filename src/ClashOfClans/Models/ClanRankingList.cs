using System.Collections.Generic;

namespace ClashOfClans.Models
{
    public class ClanRankingList : Queryable
    {
        public List<ClanRanking> Items { get; set; }
    }
}
