# Clash of Clans
.NET Standard library for Clash of Clans API

# Info
This is an API wrapper library for official Clash of Clans API, see https://developer.clashofclans.com/.
In order to use the functionality provided by this library you need an API key (token) that can be created in Clash of Clans developer web site.

# Installation
Clash of Clans API library is provided as a [NuGet package](https://www.nuget.org/packages/ClashOfClans/). You can install the NuGet package for example via Visual Studio Package Manager Console window by giving next command:
```
Install-Package ClashOfClans
```

# Usage
Below are examples about how to use the API to get the data from Supercell's Clash of Clans API.
The precondition for each API request is that you have a valid token defined in the scope of the request!
```csharp
var token = "[your own unique API key]";
```

## Get Player Information
```csharp
var playerTag = "[player tag]";
var coc = new ClashOfClansApi(token);
var player = await coc.Players.GetAsync(playerTag);
```

## Get Clan Information
```csharp
var clanTag = "[clan tag]";
var coc = new ClashOfClansApi(token);
var clan = await coc.Clans.GetAsync(clanTag);
```

## Search Clans
This example shows how to use `query` object to limit the amount of clans received.
```csharp
var coc = new ClashOfClansApi(token);
var query = new QueryClans
{
    Name = "Phoenix",
    Limit = 10
};

var searchResult = await coc.Clans.GetAsync(query);
```

## List Leagues
```csharp
var coc = new ClashOfClansApi(token);
var leagueList = await coc.Leagues.GetAsync();
```

## List Locations
```csharp
var coc = new ClashOfClansApi(token);
var locationList = await coc.Locations.GetAsync();
```

# Unit Tests
You can run unit tests by following next steps:
1. Build the `ClashOfClans.Tests` project
2. Open build output folder (at the moment `.\ClashOfClans.Tests\bin\Debug\netcoreapp2.2`) in File Explorer
3. Open `appsettings.test.json` file, add your own token and player tag and save the changes
4. Run unit tests

All unit tests should pass if you provided a valid token and player tag.
