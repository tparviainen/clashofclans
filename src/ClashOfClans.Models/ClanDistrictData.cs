namespace ClashOfClans.Models
{
    public class ClanDistrictData
    {
        private int? _id;
        private int? _districtHallLevel;

        public int Id { get => _id ?? default; set => _id = value; }

        public string Name { get; set; } = default!;

        public int DistrictHallLevel { get => _districtHallLevel ?? default; set => _districtHallLevel = value; }
    }
}
