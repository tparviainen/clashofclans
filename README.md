# Clash of Clans
.NET Standard library for Clash of Clans API

# Info
This is an API wrapper library for official Clash of Clans API, see https://developer.clashofclans.com/.
In order to use this library you need an API key (token) that can be created in Clash of Clans developer web site.

# Usage
Below is a simple example about how to use the API.
After executing the steps you get the information about the player whose tag was provided in the request.

```csharp
var token = "[your own unique API key]";
var playerTag = "[player tag]";

var coc = new ClashOfClans(token);
var player = await coc.Players.GetAsync(playerTag);
```

# Unit Tests
You can run unit tests by following next steps:
1. Build the `ClashOfClans.Tests` project
2. Open build output folder (at the moment `.\ClashOfClans.Tests\bin\Debug\netcoreapp2.2`) in File Explorer
3. Open `appsettings.test.json` file, add your own token and player tag and save the changes
4. Run unit tests

All unit tests should pass if you provided a valid token and player tag.
