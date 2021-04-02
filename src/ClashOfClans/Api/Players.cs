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

        public Task<Player> GetPlayerAsync(string playerTag)
        {
            var request = new AutoValidatedRequest
            {
                PlayerTag = playerTag,
                Uri = $"/players/{playerTag}"
            };

            return _gameData.RequestAsync<Player>(request);
        }

        public Task<VerifyTokenResponse> VerifyTokenAsync(string playerTag, string apiToken)
        {
            var request = new AutoValidatedRequest
            {
                PlayerTag = playerTag,
                Uri = $"/players/{playerTag}/verifytoken",
                Content = new VerifyTokenRequest
                {
                    Token = apiToken
                }
            };

            return _gameData.RequestAsync<VerifyTokenResponse>(request);
        }
    }
}
