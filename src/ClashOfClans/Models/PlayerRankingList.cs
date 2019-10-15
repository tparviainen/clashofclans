using System.Collections.Generic;

namespace ClashOfClans.Models
{
    public class PlayerRankingList : Queryable
    {
        public List<PlayerRanking> Items { get; set; }
    }
}
