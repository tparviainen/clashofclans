namespace ClashOfClans.Models
{
    public class PlayerLegendStatistics
    {
        public int? LegendTrophies { get; set; }

        public LegendLeagueTournamentSeasonResult BestVersusSeason { get; set; }

        public LegendLeagueTournamentSeasonResult PreviousVersusSeason { get; set; }

        public LegendLeagueTournamentSeasonResult BestSeason { get; set; }

        public LegendLeagueTournamentSeasonResult CurrentSeason { get; set; }

        public LegendLeagueTournamentSeasonResult PreviousSeason { get; set; }
    }
}
