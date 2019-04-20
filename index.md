# **Clash of Clans**
This is the homepage for .NET Standard library for Clash of Clans API. The source code for the library is available on GitHub
at [https://github.com/tparviainen/clashofclans](https://github.com/tparviainen/clashofclans)

# Getting Started

1. Create an API key (*token*) in Clash of Clans [developer web site](https://developer.clashofclans.com/).

2. Create a .NET Core project and install the latest [NuGet package](https://www.nuget.org/packages/ClashOfClans/) for example via Visual Studio Package Manager Console window by giving the next command.
```
Install-Package ClashOfClans
```

3. After NuGet package installation create an instance of the API with the token you created in *step 1*.
```csharp
var token = "[your own unique API key]";
var coc = new ClashOfClansApi(token);
```

4. The functionality provided by the Clash of Clans API is available via `ClashOfClansApi` instance. Below are few examples of how to use the API.

* Get Clan Information
```csharp
var clanTag = "[clan tag]";
var clan = await coc.Clans.GetAsync(clanTag);
Console.WriteLine($"Clan '{clan.Name}' is a level {clan.ClanLevel} clan and has {clan.Members} members");
```

* Retrieve Clan's Clan War Log
```csharp
var clanTag = "[clan tag]";
var warLog = await coc.Clans.GetWarLogAsync(clanTag);
var latest = warLog.Items.First();
Console.WriteLine($"Clan '{latest.Clan.Name}' had a war against '{latest.Opponent.Name}' that ended {latest.EndTime} UTC");
```

* Get Player Information
```csharp
var playerTag = "[player tag]";
var player = await coc.Players.GetAsync(playerTag);
Console.WriteLine($"Player '{player.Name}' is in clan '{player.Clan?.Name}'");
```

* Get League Information
```csharp
var leagues = await coc.Leagues.GetAsync();
var league = leagues["Legend League"];
Console.WriteLine($"'{league.Name}' has an ID {league.Id}");
```

* Get Location Information
```csharp
var locations = await coc.Locations.GetAsync();
var location = locations["Finland"];
Console.WriteLine($"'{location.Name}' has an ID {location.Id} and country code '{location.CountryCode}'");
```

* Search Clans
```csharp
var query = new QueryClans
{
    Limit = 1,
    WarFrequency = WarFrequency.Always
};
var clans = await coc.Clans.GetAsync(query);
var warClan = clans.Items.First();
Console.WriteLine($"Clan '{warClan.Name}' has {warClan.WarWins} wins, {warClan.WarLosses} losses and {warClan.WarTies} draws");
```

# Example Project
Clash of Clans [repository](https://github.com/tparviainen/clashofclans) contains .NET Core console application that uses the Clash of Clans API. 
The source code for the project is available at [ClashOfClans.App](https://github.com/tparviainen/clashofclans/tree/master/src/ClashOfClans.App).

Clash of Clans API is fully asynchronous and if you want to use the API directly from the console application's Main method you need
to use C# 7.1 features. More information about how to enable C# 7.1 features see 
[Select the C# language version](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/configure-language-version).
