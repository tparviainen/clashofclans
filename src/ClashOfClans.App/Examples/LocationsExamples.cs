using ClashOfClans.Models;
using ClashOfClans.Search;
using System;
using System.Threading.Tasks;

namespace ClashOfClans.App.Examples
{
    class LocationsExamples
    {
        private readonly string token;

        public LocationsExamples(string token)
        {
            this.token = token;
        }

        /// <summary>
        /// List locations
        /// </summary>
        public async Task ListLocations()
        {
            var coc = new ClashOfClansApi(token);
            var locations = (LocationList)await coc.Locations.GetLocationsAsync();

            Console.WriteLine($"Total amount of locations: {locations.Count}");

            foreach (var location in locations)
            {
                Console.WriteLine($"Id: {location.Id}, Name: {location.Name}, IsCountry: {location.IsCountry}, CountryCode: {location.CountryCode}");
            }
        }

        /// <summary>
        /// Get information about specific location
        /// </summary>
        public async Task GetLocationInformation()
        {
            var coc = new ClashOfClansApi(token);
            var locationId = 32000086; // Finland
            var location = await coc.Locations.GetLocationAsync(locationId);

            Console.WriteLine($"Id: {location.Id}, Name: {location.Name}, IsCountry: {location.IsCountry}");
        }

        /// <summary>
        /// Get clan rankings for a specific location
        /// </summary>
        public async Task GetClanRankingsForASpecificLocation()
        {
            var coc = new ClashOfClansApi(token);
            var locations = (LocationList)await coc.Locations.GetLocationsAsync();
            var location = locations["Finland"];

            Console.WriteLine($"Clan rankings for {location.Name}");

            var clanRankings = (ClanRankingList)await coc.Locations.GetClanRankingAsync(location.Id);

            foreach (var clan in clanRankings)
            {
                Console.WriteLine($"{clan.Rank}. {clan.Name}, clan level {clan.ClanLevel}");
            }
        }

        /// <summary>
        /// Get player rankings for a specific location
        /// </summary>
        public async Task GetPlayerRankingsForASpecificLocation()
        {
            var coc = new ClashOfClansApi(token);
            var locations = (LocationList)await coc.Locations.GetLocationsAsync();
            var location = locations["Finland"];
            var query = new Query
            {
                Limit = 10
            };

            var playerRankings = (PlayerRankingList)await coc.Locations.GetPlayerRankingAsync(location.Id, query);

            Console.WriteLine($"{location.Name} top {query.Limit} @ {DateTime.Now}");
            foreach (var player in playerRankings)
            {
                Console.WriteLine($"Rank {player.Rank}, {player.Trophies} \uD83C\uDFC6, player {player.Name}");
            }
        }

        /// <summary>
        /// Get clan versus rankings for a specific location
        /// </summary>
        public async Task GetClanVersusRankingsForASpecificLocation()
        {
            var coc = new ClashOfClansApi(token);
            var locations = (LocationList)await coc.Locations.GetLocationsAsync();
            var location = locations["Finland"];

            Console.WriteLine($"Clan versus rankings for {location.Name}");
            var clanVersusRankings = (ClanVersusRankingList)await coc.Locations.GetClanVersusRankingAsync(location.Id);

            foreach (var clan in clanVersusRankings)
            {
                Console.WriteLine($"{clan.Rank}. {clan.Name}, clan level {clan.ClanLevel}, {clan.ClanVersusPoints} \uD83C\uDFC6");
            }
        }

        /// <summary>
        /// Get player versus rankings for a specific location
        /// </summary>
        public async Task GetPlayerVersusRankingsForASpecificLocation()
        {
            var coc = new ClashOfClansApi(token);
            var locations = (LocationList)await coc.Locations.GetLocationsAsync();
            var location = locations["Finland"];

            var playerVersusRankings = (PlayerVersusRankingList)await coc.Locations.GetPlayerVersusRankingAsync(location.Id);

            foreach (var player in playerVersusRankings)
            {
                Console.WriteLine($"Rank {player.Rank}, {player.VersusTrophies} \uD83C\uDFC6, player {player.Name}");
            }
        }
    }
}
