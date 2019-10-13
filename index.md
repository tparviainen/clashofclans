# **Clash of Clans**
This is the homepage for .NET Standard library for Clash of Clans API. The source code for the library is available on GitHub
at [https://github.com/tparviainen/clashofclans](https://github.com/tparviainen/clashofclans)

# Getting Started

1. Create an API key (*token*) in Clash of Clans [developer web site](https://developer.clashofclans.com/).

2. Create a .NET Core project and install the latest [NuGet package](https://www.nuget.org/packages/ClashOfClans/) for example via Visual Studio Package Manager Console window by giving the next command.
```
Install-Package ClashOfClans
```

# API Usage Examples

Next variables are used in the examples below, so please set them to correct values first:

```csharp
var token = "[your own unique API key]";
var playerTag = "#abcdefg";
var clanTag = "#hijklmn";
```

## Get information about a single clan by clan tag

```csharp
var coc = new ClashOfClansApi(token);
var clan = await coc.Clans.GetAsync(clanTag);
Console.WriteLine($"Clan '{clan.Name}' is a level {clan.ClanLevel} clan and has {clan.Members} members");
```

## Retrieve clan's clan war log
Please note that clan's war log is only available from a clan that has public war log!

```csharp
var coc = new ClashOfClansApi(token);
var clan = await coc.Clans.GetAsync(clanTag);

if (clan.IsWarLogPublic == true)
{
    var warLog = await coc.Clans.GetWarLogAsync(clanTag);

    foreach (var war in warLog.Items)
    {
        Console.WriteLine($"{war.Result.ToString()[0]}: {Statistics(war.Clan)} vs {Statistics(war.Opponent)}");
    }
}

string Statistics(WarClan clan) => $"{clan.Name} [{clan.Stars}\u2605/{clan.DestructionPercentage}%]";
```

## Get information about a single player by player tag
```csharp
var coc = new ClashOfClansApi(token);
var player = await coc.Players.GetAsync(playerTag);
Console.WriteLine($"'{player.Name}' has {player.Trophies} \uD83C\uDFC6 and {player.WarStars} war stars");

if (player.Clan != null)
{
    var d = (int)player.Donations;
    var dr = (int)player.DonationsReceived;
    Console.WriteLine($"'{player.Name}' is a member of '{player.Clan.Name}' and has a donation ratio {d}/{dr}={(dr != 0 ? (d / (float)dr) : 0):0.00}");
}
```

## List leagues
```csharp
var coc = new ClashOfClansApi(token);
var leagues = await coc.Leagues.GetAsync();

Console.WriteLine($"Total amount of leagues: {leagues.Items.Count()}");

foreach (var league in leagues.Items)
{
    Console.WriteLine($"Id: {league.Id}, Name: {league.Name}");
}
```

## List locations
```csharp
var coc = new ClashOfClansApi(token);
var locations = await coc.Locations.GetAsync();

Console.WriteLine($"Total amount of locations: {locations.Items.Count()}");

foreach (var location in locations.Items)
{
    Console.WriteLine($"Id: {location.Id}, Name: {location.Name}, IsCountry: {location.IsCountry}, CountryCode: {location.CountryCode}");
}
```

# Example Project
All the above examples are copy pasted from the example project included in the Clash of Clans [repository](https://github.com/tparviainen/clashofclans). The source code for the project is available at [ClashOfClans.App](https://github.com/tparviainen/clashofclans/tree/master/src/ClashOfClans.App).

Clash of Clans API is fully asynchronous and if you want to use the API directly from the console application's Main method you need
to use C# 7.1 features. More information about how to enable C# 7.1 features see 
[Select the C# language version](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/configure-language-version).
