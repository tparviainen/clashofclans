using ClashOfClans;
using ClashOfClans.Core;
using ClashOfClans.Models;
using ClashOfClans.Search;
using System;
using System.Threading.Tasks;

namespace ClashOfClans.App
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var clanTag = "[clan tag]";
            var playerTag = "[player tag]";
            var token = "[your own unique API key]";

            var query = new QueryClans
            {
                Name = "Phoenix",
                Limit = 10,
                WarFrequency = WarFrequency.Never
            };

            try
            {
                var coc = new ClashOfClansApi(token);

                var clan = await coc.Clans.GetAsync(clanTag);           // Get Clan Information
                var warLog = await coc.Clans.GetWarLogAsync(clanTag);   // Retrieve Clans Clan War Log
                var player = await coc.Players.GetAsync(playerTag);     // Get Player Information
                var leagueList = await coc.Leagues.GetAsync();          // List Leagues
                var locationList = await coc.Locations.GetAsync();      // List Locations
                var searchResult = await coc.Clans.GetAsync(query);     // Search Clans

                // ...
            }
            catch (ClashOfClansException ex)
            {
                Console.WriteLine(ex.Error);
            }
        }
    }
}
