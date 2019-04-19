namespace ClashOfClans.Models
{
    public class InlineModel : Identity
    {
        public int? ClanLevel { get; set; }

        public UrlContainer BadgeUrls { get; set; }

        public InlineModel1[] Members { get; set; }
    }
}
