using ClashOfClans.Models;
using ClashOfClans.Search;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ClashOfClans.App.Examples
{
    public class LeaguesExamples
    {
        private readonly string token;

        public LeaguesExamples(string token)
        {
            this.token = token;
        }

        /// <summary>
        /// List leagues
        /// </summary>
        public async Task ListLeagues()
        {
            var coc = new ClashOfClansClient(token);
            var leagues = (LeagueList)await coc.Leagues.GetLeaguesAsync();

            Console.WriteLine($"Total amount of leagues: {leagues.Count}");

            foreach (var league in leagues)
            {
                Console.WriteLine($"Id: {league.Id}, Name: {league.Name}");
            }
        }

        /// <summary>
        /// Get league information
        /// </summary>
        public async Task GetLeagueInformation()
        {
            var leagueId = 29000022; // Legend League identifier
            var coc = new ClashOfClansClient(token);
            var league = await coc.Leagues.GetLeagueAsync(leagueId);

            Console.WriteLine($"Id: {league.Id} = {league.Name}");
        }

        /// <summary>
        /// Get league seasons. Note that league season information is available only for Legend League.
        /// </summary>
        public async Task GetLeagueSeasons()
        {
            var coc = new ClashOfClansClient(token);
            var leagues = (LeagueList)await coc.Leagues.GetLeaguesAsync();
            var legendLeague = leagues["Legend League"];
            var leagueSeasons = (LeagueSeasonList)await coc.Leagues.GetLeagueSeasonsAsync(legendLeague!.Id);

            Console.WriteLine($"Total amount of '{legendLeague.Name}' seasons: {leagueSeasons.Count}");

            foreach (var season in leagueSeasons)
            {
                Console.WriteLine($"{season.Id}");
            }
        }

        /// <summary>
        /// Get league season rankings. Note that league season information is available only for Legend League.
        /// </summary>
        public async Task GetLeagueSeasonRankings()
        {
            var coc = new ClashOfClansClient(token);
            var leagues = (LeagueList)await coc.Leagues.GetLeaguesAsync();
            var legendLeague = leagues["Legend League"];
            var leagueSeasons = (LeagueSeasonList)await coc.Leagues.GetLeagueSeasonsAsync(legendLeague!.Id);
            var lastSeason = leagueSeasons.Last();
            var query = new Query
            {
                Limit = 100
            };

            var playerRankings = (PlayerRankingList)await coc.Leagues.GetLeagueSeasonRankingsAsync(legendLeague.Id, lastSeason.Id, query);

            foreach (var player in playerRankings)
            {
                Console.WriteLine($"{player.Rank}. {player.Name}, {player.Trophies} \uD83C\uDFC6, attacks won {player.AttackWins}, defenses won {player.DefenseWins}");
            }
        }

        /// <summary>
        /// List war leagues
        /// </summary>
        public async Task ListWarLeagues()
        {
            var coc = new ClashOfClansClient(token);
            var warLeagues = (WarLeagueList)await coc.Leagues.GetWarLeaguesAsync();

            Console.WriteLine($"Total amount of war leagues: {warLeagues.Count}");

            foreach (var warLeague in warLeagues)
            {
                Console.WriteLine($"Id: {warLeague.Id}, Name: {warLeague.Name}");
            }
        }

        /// <summary>
        /// Get war league information
        /// </summary>
        public async Task GetWarLeagueInformation()
        {
            var warLeagueId = 48000000; // Unranked
            var coc = new ClashOfClansClient(token);
            var warLeague = await coc.Leagues.GetWarLeagueAsync(warLeagueId);

            Console.WriteLine($"Id: {warLeague.Id} = {warLeague.Name}");
        }

        /// <summary>
        /// List capital leagues
        /// </summary>
        public async Task ListCapitalLeagues()
        {
            var coc = new ClashOfClansClient(token);
            var capitalLeagues = (CapitalLeagueList)await coc.Leagues.GetCapitalLeaguesAsync();

            Console.WriteLine($"Total amount of capital leagues: {capitalLeagues.Count}");

            foreach (var capitalLeague in capitalLeagues)
            {
                Console.WriteLine($"Id: {capitalLeague.Id}, Name: {capitalLeague.Name}");
            }
        }

        /// <summary>
        /// Get capital league information
        /// </summary>
        public async Task GetCapitalLeagueInformation()
        {
            var capitalLeagueId = 85000015; // Master League I
            var coc = new ClashOfClansClient(token);
            var capitalLeague = await coc.Leagues.GetCapitalLeagueAsync(capitalLeagueId);

            Console.WriteLine($"Id: {capitalLeague.Id} = {capitalLeague.Name}");
        }
    }
}
