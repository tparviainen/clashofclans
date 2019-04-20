using ClashOfClans;
using ClashOfClans.Core;
using ClashOfClans.Models;
using ClashOfClans.Search;
using System;
using System.Linq;
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

            try
            {
                var coc = new ClashOfClansApi(token);

                // Get Clan Information
                var clan = await coc.Clans.GetAsync(clanTag);
                Console.WriteLine($"Clan '{clan.Name}' is a level {clan.ClanLevel} clan and has {clan.Members} members");

                // Retrieve Clans Clan War Log
                var warLog = await coc.Clans.GetWarLogAsync(clanTag);
                var latest = warLog.Items.First();
                Console.WriteLine($"Clan '{latest.Clan.Name}' had a war against '{latest.Opponent.Name}' that ended {latest.EndTime} UTC");

                // Get Player Information
                var player = await coc.Players.GetAsync(playerTag);
                Console.WriteLine($"Player '{player.Name}' is in clan '{player.Clan?.Name}'");

                // Get League Information
                var leagues = await coc.Leagues.GetAsync();
                var league = leagues["Legend League"];
                Console.WriteLine($"'{league.Name}' has an ID {league.Id}");

                // Get Location Information
                var locations = await coc.Locations.GetAsync();
                var location = locations["Finland"];
                Console.WriteLine($"'{location.Name}' has an ID {location.Id} and country code '{location.CountryCode}'");

                // Search Clans
                var query = new QueryClans
                {
                    Limit = 1,
                    WarFrequency = WarFrequency.Always
                };
                var clans = await coc.Clans.GetAsync(query);
                var warClan = clans.Items.First();
                Console.WriteLine($"Clan '{warClan.Name}' has {warClan.WarWins} wins, {warClan.WarLosses} losses and {warClan.WarTies} draws");
            }
            catch (ClashOfClansException ex)
            {
                Console.WriteLine(ex.Error);
            }
        }
    }
}
