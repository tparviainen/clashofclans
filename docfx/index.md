# **Clash of Clans**

This is the homepage for .NET Standard library for Clash of Clans API. The source code for the library is available on GitHub
at [https://github.com/tparviainen/clashofclans](https://github.com/tparviainen/clashofclans)

# Getting Started

1. Create an API key (*token*) in Clash of Clans [developer web site](https://developer.clashofclans.com/).

2. Create a .NET Core project and install the latest [NuGet package](https://www.nuget.org/packages/ClashOfClans/) for example via Visual Studio Package Manager Console window by giving the next command.


```C#
Install-Package ClashOfClans
```

# API Usage Examples

Next variables are used in the examples below, so please set them to correct values first:


```C#
var token = "[your own unique API key]";
var playerTag = "[player tag]";
var clanTag = "[clan tag]";
```

## Add `using`-directives


```C#
using ClashOfClans;
using ClashOfClans.Models;
using ClashOfClans.Search;
```

## Get information about a single clan by clan tag


```C#
var coc = new ClashOfClansClient(token);
var clan = await coc.Clans.GetClanAsync(clanTag);
Console.WriteLine($"Clan '{clan.Name}' is a level {clan.ClanLevel} clan and has {clan.Members} members");
```

    Clan 'Storm Nation' is a level 17 clan and has 50 members
    

## Retrieve clan's clan war log

Please note that clan's war log is only available from a clan that has public war log!


```C#
var coc = new ClashOfClansClient(token);
var clan = await coc.Clans.GetClanAsync(clanTag);

if (clan.IsWarLogPublic == true)
{
    var warLog = (ClanWarLog)await coc.Clans.GetClanWarLogAsync(clanTag);

    // Take only last 10 wars
    foreach (var war in warLog.Take(10))
    {
        Console.WriteLine($"{war.EndTime.ToString("s")} = {war.Result.ToString()[0]}: {Statistics(war.Clan)} vs {Statistics(war.Opponent)}");
    }
}

string Statistics(WarClan warClan) => $"{warClan.Name} [{warClan.Stars}\u2605/{warClan.DestructionPercentage}%]";
```

    2020-01-13T20:30:07 = L: Storm Nation [100★/55,8%] vs Mini Thieves [150★/100%]
    2020-01-11T17:04:43 = L: Storm Nation [99★/55,6%] vs вєуσи∂ ιиfιиιту [150★/100%]
    2020-01-09T16:08:03 = L: Storm Nation [95★/53,5%] vs 互刷 [119★/78,68%]
    2020-01-07T12:56:51 = L: Storm Nation [95★/51,8%] vs Bomba [131★/87,1%]
    2020-01-05T11:30:14 = L: Storm Nation [99★/55,08%] vs Farm 4 Life [119★/78,68%]
    2019-12-30T11:19:38 = W: Storm Nation [144★/96%] vs POLCATZ [100★/58,92%]
    2019-12-28T09:05:10 = W: Storm Nation [144★/95,1%] vs Farm.NL2 [100★/55,44%]
    2019-12-26T07:21:49 = W: Storm Nation [129★/86%] vs Farm X3 [71★/40,02%]
    2019-12-24T05:44:15 = W: Storm Nation [150★/100%] vs Organised Chaos [100★/56,08%]
    2019-12-21T23:42:50 = L: Storm Nation [85★/47,58%] vs ACCESS: DENIED [138★/92%]
    

## Get information about a single player by player tag


```C#
var coc = new ClashOfClansClient(token);
var player = await coc.Players.GetPlayerAsync(playerTag);
Console.WriteLine($"'{player.Name}' has {player.Trophies} \uD83C\uDFC6 and {player.WarStars} war \u2B50");

if (player.Clan != null)
{
    var d = (int)player.Donations;
    var dr = (int)player.DonationsReceived;
    Console.WriteLine($"'{player.Name}' is a member of '{player.Clan.Name}' and has a donation ratio {d}/{dr}={(dr != 0 ? (d / (float)dr) : 0):0.00}");
}
```

    '--[t0m1]--' has 2974 🏆 and 2140 war ⭐
    '--[t0m1]--' is a member of 'Storm Nation' and has a donation ratio 1553/2101=0,74
    

## List leagues


```C#
var coc = new ClashOfClansClient(token);
var leagues = (LeagueList)await coc.Leagues.GetLeaguesAsync();

Console.WriteLine($"Total amount of leagues: {leagues.Count}");

foreach (var league in leagues)
{
    Console.WriteLine($"Id: {league.Id}, Name: {league.Name}");
}
```

    Total amount of leagues: 23
    Id: 29000000, Name: Unranked
    Id: 29000001, Name: Bronze League III
    Id: 29000002, Name: Bronze League II
    Id: 29000003, Name: Bronze League I
    Id: 29000004, Name: Silver League III
    Id: 29000005, Name: Silver League II
    Id: 29000006, Name: Silver League I
    Id: 29000007, Name: Gold League III
    Id: 29000008, Name: Gold League II
    Id: 29000009, Name: Gold League I
    Id: 29000010, Name: Crystal League III
    Id: 29000011, Name: Crystal League II
    Id: 29000012, Name: Crystal League I
    Id: 29000013, Name: Master League III
    Id: 29000014, Name: Master League II
    Id: 29000015, Name: Master League I
    Id: 29000016, Name: Champion League III
    Id: 29000017, Name: Champion League II
    Id: 29000018, Name: Champion League I
    Id: 29000019, Name: Titan League III
    Id: 29000020, Name: Titan League II
    Id: 29000021, Name: Titan League I
    Id: 29000022, Name: Legend League
    

## List locations


```C#
var coc = new ClashOfClansClient(token);
var locations = (LocationList)await coc.Locations.GetLocationsAsync();

Console.WriteLine($"Total amount of locations: {locations.Count}");

foreach (var location in locations.Where(l => l.Name.StartsWith("E")))
{
    Console.Write($"Id: {location.Id}, Name: {location.Name}, IsCountry: {location.IsCountry}");
    if (location.IsCountry == true)
        Console.Write($", CountryCode: {location.CountryCode}");

    Console.WriteLine();
}
```

    Total amount of locations: 266
    Id: 32000000, Name: Europe, IsCountry: False
    Id: 32000076, Name: Ecuador, IsCountry: True, CountryCode: EC
    Id: 32000077, Name: Egypt, IsCountry: True, CountryCode: EG
    Id: 32000078, Name: El Salvador, IsCountry: True, CountryCode: SV
    Id: 32000079, Name: Equatorial Guinea, IsCountry: True, CountryCode: GQ
    Id: 32000080, Name: Eritrea, IsCountry: True, CountryCode: ER
    Id: 32000081, Name: Estonia, IsCountry: True, CountryCode: EE
    Id: 32000082, Name: Ethiopia, IsCountry: True, CountryCode: ET
    

# Example Project

All the above examples can be found from the example project included in the Clash of Clans [repository](https://github.com/tparviainen/clashofclans). The source code for the project is available at [ClashOfClans.App](https://github.com/tparviainen/clashofclans/tree/master/src/ClashOfClans.App).

Clash of Clans API is fully asynchronous and if you want to use the API directly from the console application's Main method you need
to use C# 7.1 features. More information about how to enable C# 7.1 features see 
[Select the C# language version](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/configure-language-version).
