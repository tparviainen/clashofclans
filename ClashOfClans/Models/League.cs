namespace ClashOfClans.Models
{
    public class League
    {
        public int? Id;

        public string Name;

        public UrlContainer IconUrls;

        public override string ToString()
        {
            return $"League: Id {Id}, Name '{Name}'";
        }
    }
}