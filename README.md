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

namespace Clash
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

# Unit Tests
You can run unit tests by following next steps:
1. Build the `ClashOfClans.Tests` project
2. Open build output folder (at the moment `.\ClashOfClans.Tests\bin\Debug\netcoreapp2.2`) in File Explorer
3. Open `appsettings.test.json` file, add your own token and player tag and save the changes
4. Run unit tests

All unit tests should pass if you provided a valid token and player tag.
