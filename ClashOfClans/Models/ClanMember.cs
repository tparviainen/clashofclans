namespace ClashOfClans.Models
{
    public class ClanMember : Identity
    {
        public string Role { get; set; }

        public int? ExpLevel { get; set; }

        public League League { get; set; }

        public int? Trophies { get; set; }

        public int? VersusTrophies { get; set; }

        public int? ClanRank { get; set; }

        public int? PreviousClanRank { get; set; }

        public int? Donations { get; set; }

        public int? DonationsReceived { get; set; }
    }
}
