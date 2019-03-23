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
