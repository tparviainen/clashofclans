namespace ClashOfClans.Models
{
    public class Language
    {
        private int? _id;

        public int Id { get => _id ?? default; set => _id = value; }

        public string Name { get; set; } = default!;

        public string LanguageCode { get; set; } = default!;
    }
}
