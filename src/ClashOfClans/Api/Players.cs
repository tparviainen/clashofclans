using ClashOfClans.Core;
using ClashOfClans.Models;
using System.Threading.Tasks;

#nullable enable

namespace ClashOfClans.Api
{
    internal class Players : IPlayers
    {
        private readonly IGameData _gameData;

        public Players(IGameData gameData)
        {
            _gameData = gameData;
        }

        public Task<Player> GetPlayerAsync(string playerTag)
        {
            var request = new AutoValidatedRequest
            {
                PlayerTag = playerTag,
                Uri = $"/players/{playerTag}"
            };

            return _gameData.RequestAsync<Player>(request);
        }
    }
}
