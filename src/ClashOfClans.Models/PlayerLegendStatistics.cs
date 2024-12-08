namespace ClashOfClans.Models
{
    public class PlayerLegendStatistics
    {
        public int LegendTrophies { get; set; }

        public LegendLeagueTournamentSeasonResult? BestSeason { get; set; }

        public LegendLeagueTournamentSeasonResult CurrentSeason { get; set; } = default!;

        public LegendLeagueTournamentSeasonResult? PreviousSeason { get; set; }

        public LegendLeagueTournamentSeasonResult? PreviousBuilderBaseSeason { get; set; }

        public LegendLeagueTournamentSeasonResult? BestBuilderBaseSeason { get; set; }
    }
}
