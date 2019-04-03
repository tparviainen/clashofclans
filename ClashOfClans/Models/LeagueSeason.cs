namespace ClashOfClans.Models
{
    public class LeagueSeason
    {
        public string Id { get; set; }

        public override string ToString()
        {
            return $"LeagueSeason: '{Id}'";
        }
    }
}
