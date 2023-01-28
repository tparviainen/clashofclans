namespace ClashOfClans.Models
{
    public class PlayerHouseElement
    {
        private int? _id;

        public int Id { get => _id ?? default; set => _id = value; }

        public PlayerHouseElementType? Type { get; set; }
    }
}
