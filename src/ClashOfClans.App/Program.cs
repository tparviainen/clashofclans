using ClashOfClans.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace ClashOfClans.App
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            AddConfigurationValues(out string clanTag, out string playerTag, out string token);

            try
            {
                // Access clan specific information
                var clansExamples = new ClansExamples(token, clanTag);
                await clansExamples.GetClanInformation();
                await clansExamples.RetrieveClansClanWarLog();

                // Access player specific information
                var playersExamples = new PlayersExamples(token, playerTag);
                await playersExamples.GetPlayerInformation();

                // Access league information
                var leaguesExamples = new LeaguesExamples(token);
                await leaguesExamples.ListLeagues();
                await leaguesExamples.GetLeagueSeasons();
                await leaguesExamples.GetLeagueSeasonRankings();

                // Access global and local rankings
                var locationsExamples = new LocationsExamples(token);
                await locationsExamples.ListLocations();
                await locationsExamples.GetClanRankingsForASpecificLocation();
            }
            catch (ClashOfClansException ex)
            {
                Console.WriteLine(ex.Error);
            }
        }

        /// <summary>
        /// Reads the configuration values from the JSON file
        /// </summary>
        private static void AddConfigurationValues(out string clanTag, out string playerTag, out string token)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            token = config["api:token"];
            clanTag = config["clanTag"];
            playerTag = config["playerTag"];
        }
    }
}
