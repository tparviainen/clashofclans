namespace ClashOfClans.Models
{
    public class ClanCapital
    {
        public int CapitalHallLevel { get; set; }

        public ClanDistrictDataList Districts { get; set; } = default!;
    }
}
