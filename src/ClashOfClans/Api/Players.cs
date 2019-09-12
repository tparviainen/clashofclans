using ClashOfClans.Core;
using ClashOfClans.Models;
using ClashOfClans.Validation;
using System.Threading.Tasks;

namespace ClashOfClans.Api
{
    internal class Players : IPlayers
    {
        private readonly IGameData _gameData;
        private readonly Validator _validator;

        public Players(IGameData gameData, Validator validator)
        {
            _gameData = gameData;
            _validator = validator;
        }

        // GET /players/{playerTag}
        public async Task<Player> GetAsync(string playerTag)
        {
            _validator.ValidatePlayerTag(playerTag);

            var uri = $"players/{playerTag}";

            return await _gameData.RequestAsync<Player>(uri);
        }
    }
}
