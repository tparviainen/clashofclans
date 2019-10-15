using System.Collections.Generic;

namespace ClashOfClans.Models
{
    public class ClanVersusRankingList : Queryable
    {
        public List<ClanVersusRanking> Items { get; set; }
    }
}
