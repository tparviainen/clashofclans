using ClashOfClans.Models;
using ClashOfClans.Search;
using System;
using System.Threading.Tasks;

namespace ClashOfClans.App.Examples;

public class LocationsExamples
{
    private readonly string _token;

    public LocationsExamples(string token)
    {
        _token = token;
    }

    /// <summary>
    /// List locations
    /// </summary>
    public async Task ListLocations()
    {
        var coc = new ClashOfClansClient(_token);
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
        var coc = new ClashOfClansClient(_token);
        var locationId = 32000086; // Finland
        var location = await coc.Locations.GetLocationAsync(locationId);

        Console.WriteLine($"Id: {location.Id}, Name: {location.Name}, IsCountry: {location.IsCountry}");
    }

    /// <summary>
    /// Get clan rankings for a specific location
    /// </summary>
    public async Task GetClanRankingsForASpecificLocation()
    {
        var coc = new ClashOfClansClient(_token);
        var locations = (LocationList)await coc.Locations.GetLocationsAsync();
        var location = locations["Finland"];

        Console.WriteLine($"Clan rankings for {location!.Name}");

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
        var coc = new ClashOfClansClient(_token);
        var locations = (LocationList)await coc.Locations.GetLocationsAsync();
        var location = locations["Finland"];
        var query = new Query
        {
            Limit = 10
        };

        var playerRankings = (PlayerRankingList)await coc.Locations.GetPlayerRankingAsync(location!.Id, query);

        Console.WriteLine($"{location.Name} top {query.Limit} @ {DateTime.Now}");
        foreach (var player in playerRankings)
        {
            Console.WriteLine($"Rank {player.Rank}, {player.Trophies} \uD83C\uDFC6, player {player.Name}");
        }
    }

    /// <summary>
    /// Get clan Builder Base rankings for a specific location
    /// </summary>
    public async Task GetClanBuilderBaseRankingsForASpecificLocation()
    {
        var coc = new ClashOfClansClient(_token);
        var locations = (LocationList)await coc.Locations.GetLocationsAsync();
        var location = locations["Finland"];

        Console.WriteLine($"Clan builder base rankings for {location!.Name}");
        var clanBuilderBaseRankings = (ClanBuilderBaseRankingList)await coc.Locations.GetClanBuilderBaseRankingAsync(location.Id);

        foreach (var clan in clanBuilderBaseRankings)
        {
            Console.WriteLine($"{clan.Rank}. {clan.Name}, clan level {clan.ClanLevel}, {clan.ClanBuilderBasePoints} \uD83C\uDFC6");
        }
    }

    /// <summary>
    /// Get player Builder Base rankings for a specific location
    /// </summary>
    public async Task GetPlayerBuilderBaseRankingsForASpecificLocation()
    {
        var coc = new ClashOfClansClient(_token);
        var locations = (LocationList)await coc.Locations.GetLocationsAsync();
        var location = locations["Finland"];

        var playerBuilderBaseRankings = (PlayerBuilderBaseRankingList)await coc.Locations.GetPlayerBuilderBaseRankingAsync(location!.Id);

        foreach (var player in playerBuilderBaseRankings)
        {
            Console.WriteLine($"Rank {player.Rank}, {player.BuilderBaseTrophies} \uD83C\uDFC6, player {player.Name}");
        }
    }

    /// <summary>
    /// Get capital rankings for a specific location
    /// </summary>
    public async Task GetCapitalRankingsForASpecificLocation()
    {
        var coc = new ClashOfClansClient(_token);
        var locations = (LocationList)await coc.Locations.GetLocationsAsync();
        var location = locations["Finland"];

        var clanCapitalRankingList = (ClanCapitalRankingList)await coc.Locations.GetClanCapitalRankingAsync(location!.Id);

        foreach (var clan in clanCapitalRankingList)
        {
            Console.WriteLine($"Rank {clan.Rank}, {clan.ClanCapitalPoints} \uD83C\uDFC6, clan {clan.Name}");
        }
    }
}
