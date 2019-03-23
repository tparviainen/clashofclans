namespace ClashOfClans.Models
{
    public class ClanBase : Identity
    {
        public string Type;

        public Location Location;

        public UrlContainer BadgeUrls;

        public int? ClanLevel;

        public int? ClanPoints;

        public int? ClanVersusPoints;

        public int? RequiredTrophies;

        public string WarFrequency;

        public int? WarWinStreak;

        public int? WarWins;

        public bool? IsWarLogPublic;

        public int? Members;

        public int? WarTies;

        public int? WarLosses;

        public override string ToString()
        {
            return $"Clan: {base.ToString()}";
        }
    }
}