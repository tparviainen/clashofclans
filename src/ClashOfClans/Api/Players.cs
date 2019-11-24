using ClashOfClans.Core;
using ClashOfClans.Models;
using System.Threading.Tasks;

namespace ClashOfClans.Api
{
    internal class Players : IPlayers
    {
        private readonly IGameData _gameData;

        public Players(IGameData gameData)
        {
            _gameData = gameData;
        }

        public async Task<Player> GetPlayerAsync(string playerTag)
        {
            var request = new AutoValidatedRequest
            {
                PlayerTag = playerTag,
                Uri = $"/players/{playerTag}"
            };

            return await _gameData.RequestAsync<Player>(request);
        }
    }
}
