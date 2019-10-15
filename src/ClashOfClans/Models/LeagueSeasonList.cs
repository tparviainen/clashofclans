using System.Collections.Generic;

namespace ClashOfClans.Models
{
    public class LeagueSeasonList : Queryable
    {
        public List<LeagueSeason> Items { get; set; }
    }
}
