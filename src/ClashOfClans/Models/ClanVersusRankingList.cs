using System;
using System.Collections.Generic;
using System.Text;

namespace ClashOfClans.Models
{
    public class ClanVersusRankingList : Queryable
    {
        public ClanVersusRanking[] Items { get; set; }
    }
}
