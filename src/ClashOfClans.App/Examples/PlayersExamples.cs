using System;
using System.Threading.Tasks;

namespace ClashOfClans.App.Examples;

public class PlayersExamples
{
    private readonly string _token;
    private readonly string _playerTag;

    public PlayersExamples(string token, string playerTag)
    {
        _token = token;
        _playerTag = playerTag;
    }

    /// <summary>
    /// Get information about a single player by player tag.
    /// </summary>
    public async Task GetPlayerInformation()
    {
        var coc = new ClashOfClansClient(_token);
        var player = await coc.Players.GetPlayerAsync(_playerTag);
        Console.WriteLine($"'{player.Name}' has {player.Trophies} \uD83C\uDFC6 and {player.WarStars} war stars");

        if (player.Clan != null)
        {
            var d = player.Donations;
            var dr = player.DonationsReceived;
            Console.WriteLine($"'{player.Name}' is a member of '{player.Clan.Name}' and has a donation ratio {d}/{dr}={(dr != 0 ? (d / (float)dr) : 0):0.00}");
        }
    }

    /// <summary>
    /// Verify player API token that can be found from the game settings
    /// </summary>
    public async Task VerifyPlayerApiToken()
    {
        var playerApiToken = "123456789";
        var coc = new ClashOfClansClient(_token);
        var result = await coc.Players.VerifyTokenAsync(_playerTag, playerApiToken);

        Console.WriteLine($"Player '{result.Tag}' API token '{result.Token}' status '{result.Status}'");
    }
}
