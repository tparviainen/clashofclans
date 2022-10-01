namespace ClashOfClans.Models
{
    public class ClanCapital
    {
        private int? _capitalHallLevel;

        public int CapitalHallLevel { get => _capitalHallLevel ?? default; set => _capitalHallLevel = value; }

        public ClanDistrictDataList Districts { get; set; } = default!;
    }
}
