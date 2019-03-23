namespace ClashOfClans.Models
{
    public class WarClan : Identity
    {
        public UrlContainer BadgeUrls;

        public int? ClanLevel;

        public int? Attacks;

        public int? Stars;

        public float? DestructionPercentage;

        public int? ExpEarned;

        public ClanWarMember[] Members;
    }
}