namespace ClashOfClans.Models
{
    public class ClanWarLeagueWarClan : Identity
    {
        public UrlContainer BadgeUrls;

        public int? ClanLevel;

        public int? Attacks;

        public int? Stars;

        public float? DestructionPercentage;

        public ClanWarMember[] Members;
    }
}