﻿using ClashOfClans.Models;
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
            var locations = await coc.Locations.GetLocationsAsync();

            Console.WriteLine($"Total amount of locations: {locations.Items.Count}");

            foreach (var location in locations.Items)
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

            var clanRankings = await coc.Locations.GetClanRankingAsync(location.Id);

            foreach (var clan in clanRankings.Items)
            {
                Console.WriteLine($"{clan.Rank}. {clan.Name}, clan level {clan.ClanLevel}");
            }
        }
    }
}
