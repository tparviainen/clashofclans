# Clash of Clans
<img align="right" width="100px" src="https://github.com/tparviainen/clashofclans/raw/master/icon.png" />

[![Version](https://img.shields.io/nuget/v/ClashOfClans.svg)](https://www.nuget.org/packages/ClashOfClans)
[![License](https://img.shields.io/github/license/tparviainen/clashofclans.svg)](https://github.com/tparviainen/clashofclans/blob/master/LICENSE)
![Downloads](https://img.shields.io/nuget/dt/ClashOfClans.svg)

.NET Standard library for Clash of Clans API

# Info
This repository contains a .NET Standard library for accessing Supercell's 
[Clash of Clans API](https://developer.clashofclans.com/).
In order to use the functionality provided by this library you need an API key (token) that can be 
created in Clash of Clans [developer web site](https://developer.clashofclans.com/).

# Getting Started
Install the latest [NuGet package](https://www.nuget.org/packages/ClashOfClans/) for example via Visual Studio Package Manager Console window by giving the next command:
```
Install-Package ClashOfClans
```

After NuGet package installation start to use the API:

```csharp
using ClashOfClans;
using ClashOfClans.Core;
using ClashOfClans.Models;
using ClashOfClans.Search;
using System;
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

            var query = new QueryClans
            {
                Name = "Phoenix",
                Limit = 10,
                WarFrequency = WarFrequency.Never
            };

            try
            {
                var coc = new ClashOfClansApi(token);

                var clan = await coc.Clans.GetAsync(clanTag);           // Get Clan Information
                var warLog = await coc.Clans.GetWarLogAsync(clanTag);   // Retrieve Clans Clan War Log
                var player = await coc.Players.GetAsync(playerTag);     // Get Player Information
                var leagueList = await coc.Leagues.GetAsync();          // List Leagues
                var locationList = await coc.Locations.GetAsync();      // List Locations
                var searchResult = await coc.Clans.GetAsync(query);     // Search Clans

                // Usage ...
                Console.WriteLine($"Player '{player.Name}' is in clan '{player.Clan?.Name}'");
                Console.WriteLine($"Clan '{clan.Name}' has {clan.Members} members");
            }
            catch (ClashOfClansException ex)
            {
                Console.WriteLine(ex.Error);
            }
        }
    }
}
```

The above code example is from the ClashOfClans.App project that is included to this repository.
