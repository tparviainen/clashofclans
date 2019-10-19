using System.Collections.Generic;

namespace ClashOfClans.Models
{
    public class PlayerVersusRankingList : Queryable
    {
        public List<PlayerVersusRanking> Items { get; set; }
    }
}
