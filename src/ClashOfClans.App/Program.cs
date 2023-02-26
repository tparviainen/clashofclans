using ClashOfClans.App.Examples;
using ClashOfClans.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace ClashOfClans.App
{
    /// <summary>
    /// The examples each create own ClashOfClansClient instance in order for each example
    /// to be standalone. Normally you would create one instance of ClashOfClansClient and
    /// use it everywhere in your application!
    /// </summary>
    static class Program
    {
        static async Task Main(string[] _)
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
                await clansExamples.RetrieveInformationAboutClansCurrentClanWarLeagueGroup();
                await clansExamples.RetrieveClansCapitalRaidSeasons();

                // Access player specific information
                var playersExamples = new PlayersExamples(token, playerTag);
                await playersExamples.GetPlayerInformation();
                await playersExamples.VerifyPlayerApiToken();

                // Access league information
                var leaguesExamples = new LeaguesExamples(token);
                await leaguesExamples.ListLeagues();
                await leaguesExamples.GetLeagueInformation();
                await leaguesExamples.GetLeagueSeasons();
                await leaguesExamples.GetLeagueSeasonRankings();
                await leaguesExamples.ListWarLeagues();
                await leaguesExamples.GetWarLeagueInformation();
                await leaguesExamples.ListCapitalLeagues();
                await leaguesExamples.GetCapitalLeagueInformation();

                // Access global and local rankings
                var locationsExamples = new LocationsExamples(token);
                await locationsExamples.ListLocations();
                await locationsExamples.GetLocationInformation();
                await locationsExamples.GetClanRankingsForASpecificLocation();
                await locationsExamples.GetPlayerRankingsForASpecificLocation();
                await locationsExamples.GetClanVersusRankingsForASpecificLocation();
                await locationsExamples.GetPlayerVersusRankingsForASpecificLocation();
                await locationsExamples.GetCapitalRankingsForASpecificLocation();

                // Access information about gold pass
                var goldPassExamples = new GoldPassExamples(token);
                await goldPassExamples.GetCurrentGoldPassSeason();

                // Access labels
                var labelsExamples = new LabelsExamples(token);
                await labelsExamples.ListClanLabels();
                await labelsExamples.ListPlayerLabels();
            }
            catch (ClashOfClansException ex)
            {
                Console.WriteLine($"Exception: {ex.Error.Reason}, {ex.Error.Message}");
                Console.WriteLine($"StackTrace:{Environment.NewLine + ex.StackTrace}");
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

            token = GetConfigurationValue(config["api:token"]);
            clanTag = GetConfigurationValue(config["clanTag"]);
            playerTag = GetConfigurationValue(config["playerTag"]);

            static string GetConfigurationValue(string? value)
                => value ?? throw new NullReferenceException();
        }
    }
}
