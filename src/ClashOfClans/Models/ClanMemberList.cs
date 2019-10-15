using System.Collections.Generic;

namespace ClashOfClans.Models
{
    public class ClanMemberList : Queryable
    {
        public List<ClanMember> Items { get; set; }
    }
}
