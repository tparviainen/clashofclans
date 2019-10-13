using System;
using System.Linq;
using System.Threading.Tasks;

namespace ClashOfClans.App
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
            var locations = await coc.Locations.GetAsync();

            Console.WriteLine($"Total amount of locations: {locations.Items.Count()}");

            foreach (var location in locations.Items)
            {
                Console.WriteLine($"Id: {location.Id}, Name: {location.Name}, IsCountry: {location.IsCountry}, CountryCode: {location.CountryCode}");
            }
        }

        /// <summary>
        /// Get clan rankings for a specific location
        /// </summary>
        public async Task GetClanRankingsForASpecificLocation()
        {
            var coc = new ClashOfClansApi(token);
            var locations = await coc.Locations.GetAsync();
            var location = locations["Finland"];

            Console.WriteLine($"Clan rankings for {location.Name}");

            var clanRankings = await coc.Locations.GetRankingsClansAsync(location.Id);

            foreach (var clan in clanRankings.Items)
            {
                Console.WriteLine($"{clan.Rank}. {clan.Name}, clan level {clan.ClanLevel}");
            }
        }
    }
}
