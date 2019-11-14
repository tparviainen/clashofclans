using ClashOfClans.App.Examples;
using ClashOfClans.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace ClashOfClans.App
{
    /// <summary>
    /// The examples each create own ClashOfClansApi instance in order for each example
    /// to be standalone. Normally you would create one instance of ClashOfClansApi and
    /// use it everywhere in your application!
    /// </summary>
    static class Program
    {
        static async Task Main(string[] args)
        {
            AddConfigurationValues(out string clanTag, out string playerTag, out string token);

            try
            {
                // Access clan specific information
                var clansExamples = new ClansExamples(token, clanTag);
                await clansExamples.SearchClans();
                await clansExamples.GetClanInformation();
                await clansExamples.ListClanMembers();
                await clansExamples.RetrieveClansClanWarLog();
                await clansExamples.RetrieveInformationAboutClansCurrentClanWar();

                // Access player specific information
                var playersExamples = new PlayersExamples(token, playerTag);
                await playersExamples.GetPlayerInformation();

                // Access league information
                var leaguesExamples = new LeaguesExamples(token);
                await leaguesExamples.ListLeagues();
                await leaguesExamples.GetLeagueInformation();
                await leaguesExamples.GetLeagueSeasons();
                await leaguesExamples.GetLeagueSeasonRankings();

                // Access global and local rankings
                var locationsExamples = new LocationsExamples(token);
                await locationsExamples.ListLocations();
                await locationsExamples.GetLocationInformation();
                await locationsExamples.GetClanRankingsForASpecificLocation();

                // Access labels
                var labelsExamples = new LabelsExamples(token);
                await labelsExamples.ListClanLabels();
                await labelsExamples.ListPlayerLabels();
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
