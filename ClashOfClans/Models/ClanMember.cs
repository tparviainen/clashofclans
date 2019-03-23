namespace ClashOfClans.Models
{
    public class ClanMember : Identity
    {
        public string Role;

        public int? ExpLevel;

        public League League;

        public int? Trophies;

        public int? VersusTrophies;

        public int? ClanRank;

        public int? PreviousClanRank;

        public int? Donations;

        public int? DonationsReceived;
    }
}