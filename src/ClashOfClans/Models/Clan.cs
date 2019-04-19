namespace ClashOfClans.Models
{
    public class Clan : ClanBase
    {
        public string Description { get; set; }

        public ClanMember[] MemberList { get; set; }
    }
}
