using ClashOfClans.Core;
using ClashOfClans.Models;
using System.Threading.Tasks;

namespace ClashOfClans.Api
{
    internal class GoldPass : IGoldPass
    {
        private readonly IGameData _gameData;

        public GoldPass(IGameData gameData)
        {
            _gameData = gameData;
        }

        public Task<GoldPassSeason> GetCurrentGoldPassSeasonAsync()
        {
            var request = new AutoValidatedRequest
            {
                Uri = $"/goldpass/seasons/current"
            };

            return _gameData.RequestAsync<GoldPassSeason>(request);
        }
    }
}
