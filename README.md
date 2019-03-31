# Clash of Clans
.NET Standard library for Clash of Clans API

[![Version](https://img.shields.io/nuget/v/ClashOfClans.svg)](https://www.nuget.org/packages/ClashOfClans)

# Info
This is a C# library for official Clash of Clans API, see https://developer.clashofclans.com/.
In order to use the functionality provided by this library you need an API key (token) that can be created in Clash of Clans [developer web site](https://developer.clashofclans.com/).

# Installation
You can install the [NuGet package](https://www.nuget.org/packages/ClashOfClans/) for example via Visual Studio Package Manager Console window by giving the next command:
```
Install-Package ClashOfClans
```

# Usage
Below are few examples about how to use the API to get data from Supercell's Clash of Clans API.

```csharp
var clanTag = "[clan tag]";
var playerTag = "[player tag]";
var token = "[your own unique API key]";

var query = new QueryClans
{
    Name = "Phoenix",
    Limit = 10
};

var coc = new ClashOfClansApi(token);

var clan = await coc.Clans.GetAsync(clanTag);       // Get Clan Information
var player = await coc.Players.GetAsync(playerTag); // Get Player Information
var leagueList = await coc.Leagues.GetAsync();      // List Leagues
var locationList = await coc.Locations.GetAsync();  // List Locations
var searchResult = await coc.Clans.GetAsync(query); // Search Clans
```

# Unit Tests
You can run unit tests by following next steps:
1. Build the `ClashOfClans.Tests` project
2. Open build output folder (at the moment `.\ClashOfClans.Tests\bin\Debug\netcoreapp2.2`) in File Explorer
3. Open `appsettings.test.json` file, add your own token and player tag and save the changes
4. Run unit tests

All unit tests should pass if you provided a valid token and player tag.
