namespace ClashOfClans.Models
{
    public class PlayerLegendStatistics
    {
        private int? _legendTrophies;

        public int LegendTrophies { get => _legendTrophies ?? default; set => _legendTrophies = value; }

        public LegendLeagueTournamentSeasonResult? BestVersusSeason { get; set; }

        public LegendLeagueTournamentSeasonResult? PreviousVersusSeason { get; set; }

        public LegendLeagueTournamentSeasonResult? BestSeason { get; set; }

        public LegendLeagueTournamentSeasonResult CurrentSeason { get; set; } = default!;

        public LegendLeagueTournamentSeasonResult? PreviousSeason { get; set; }

        public LegendLeagueTournamentSeasonResult? PreviousBuilderBaseSeason { get; set; }

        public LegendLeagueTournamentSeasonResult? BestBuilderBaseSeason { get; set; }
    }
}
