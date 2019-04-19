namespace ClashOfClans.Models
{
    public class League
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public UrlContainer IconUrls { get; set; }

        public override string ToString()
        {
            return $"League: Id {Id}, Name '{Name}'";
        }
    }
}
