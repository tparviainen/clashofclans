# Clash of Clans
[![Version](https://img.shields.io/nuget/v/ClashOfClans.svg)](https://www.nuget.org/packages/ClashOfClans)
[![License](https://img.shields.io/github/license/tparviainen/clashofclans.svg)](https://github.com/tparviainen/clashofclans/blob/master/LICENSE)

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
                Limit = 10
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

                // ...
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
