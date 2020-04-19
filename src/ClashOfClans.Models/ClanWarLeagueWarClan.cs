using System.Collections.Generic;

namespace ClashOfClans.Models
{
    public class ClanWarLeagueWarClan : Identity
    {
        public UrlContainer BadgeUrls { get; set; }

        public int? ClanLevel { get; set; }

        public int? Attacks { get; set; }

        public int? Stars { get; set; }

        public float? DestructionPercentage { get; set; }

        public List<ClanWarMember> Members { get; set; }
    }
}
