namespace ClashOfClans.Models
{
    public class LegendLeagueTournamentSeasonResult
    {
        private int? _trophies;

        public string? Id { get; set; }

        public int? Rank { get; set; }

        public int Trophies { get => _trophies ?? default; set => _trophies = value; }
    }
}
