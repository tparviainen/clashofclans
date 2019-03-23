namespace ClashOfClans.Models
{
    public class Location
    {
        public int? Id;

        public string Name;

        public bool? IsCountry;

        public string CountryCode;

        public override string ToString()
        {
            return $"Location: Name '{Name}'";
        }
    }
}