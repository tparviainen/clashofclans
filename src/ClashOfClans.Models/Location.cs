namespace ClashOfClans.Models
{
    public class Location
    {
        private int? _id;
        private bool? _isCountry;

        public int Id { get => _id ?? default; set => _id = value; }

        public string Name { get; set; } = default!;

        public bool IsCountry { get => _isCountry ?? default; set => _isCountry = value; }

        public string? CountryCode { get; set; }
    }
}
