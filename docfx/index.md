# **Clash of Clans**

This is the homepage for .NET Standard library for Clash of Clans API. The source code for the library is available on GitHub
at [https://github.com/tparviainen/clashofclans](https://github.com/tparviainen/clashofclans)

# Getting Started

1. Create an API key (*token*) in Clash of Clans [developer web site](https://developer.clashofclans.com/).

2. Create a .NET project and install the latest [NuGet package](https://www.nuget.org/packages/ClashOfClans/) for example via Visual Studio Package Manager Console window by giving the next command.


```C#
Install-Package ClashOfClans
```


# API Usage

Clash of Clans NuGet library supports two different ways of using the API, via **dependency injection (DI)** or by instantiating `ClashOfClansClient`. Below are the steps needed to start using the API in either way.


## Dependency Injection (DI)

When using the functionality via DI you add the Clash of Clans interfaces to service collection as part of service configuration and then inject the needed interfaces to controllers or services that need the Clash of Clans API functionality.

```C#
public void ConfigureServices(IServiceCollection services)
{
    :

    services.AddClashOfClans(options =>
    {
        options.Tokens.Add("[your own unique API key]");
    });
}
```

The injectable interfaces are the main interface `IClashOfClans` or more specific interfaces `IClans`, `ILocations`, `ILeagues`, `IPlayers`, `ILabels` or `IGoldPass`.

\* Support for DI came in version 8.4.0-rc1 of the NuGet package.


## ClashOfClansClient

You can also create an instance of `ClashOfClansClient` directly in your code and use the API via the created object.

```C#
var coc = new ClashOfClansClient("[your own unique API key]");
```

Once you have instantiated the object you can start using the API functionality.

```C#
var clan = await coc.Clans.GetClanAsync("[clan tag]");

Console.WriteLine($"Clan '{clan.Name}' is a level {clan.ClanLevel} clan and has {clan.Members} members");
```


# Common

Clash of Clans functionality is divided to few different namespaces. Next is a list of the most common namespaces that you need to add to your source code to use the Clash of Clans library.

```C#
using ClashOfClans;
using ClashOfClans.Core;
using ClashOfClans.Models;
using ClashOfClans.Search;
```


# Example Projects

Usage examples can be found from the Clash of Clans [repository](https://github.com/tparviainen/clashofclans).
* The source code for console app is available at `src/`[ClashOfClans.App](https://github.com/tparviainen/clashofclans/tree/develop/src/ClashOfClans.App)
* The source code for Blazor app is available at `src/`[ClashOfClans.Blazor](https://github.com/tparviainen/clashofclans/tree/develop/src/ClashOfClans.Blazor)
* The source code for Jupyter notebooks is available at `notebooks/`[*](https://github.com/tparviainen/clashofclans/tree/develop/notebooks)

Clash of Clans API is fully asynchronous and if you want to use the API directly from the console application's Main method you need
to use C# 7.1 features. More information about how to enable C# 7.1 features see 
[Select the C# language version](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/configure-language-version).
