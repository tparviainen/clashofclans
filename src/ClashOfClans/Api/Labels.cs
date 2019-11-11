using ClashOfClans.Core;
using ClashOfClans.Models;
using ClashOfClans.Search;
using ClashOfClans.Validation;
using System.Threading.Tasks;

namespace ClashOfClans.Api
{
    internal class Labels : ILabels
    {
        private readonly IGameData _gameData;
        private readonly Validator _validator;

        public Labels(IGameData gameData, Validator validator)
        {
            _gameData = gameData;
            _validator = validator;
        }

        // GET /labels/clans
        public async Task<ItemList<LabelList>> GetClanLabelsAsync(Query query = null)
        {
            _validator.ValidateQuery(query);

            var uri = $"labels/clans{query}";

            return await _gameData.RequestAsync<ItemList<LabelList>>(uri);
        }

        // GET /labels/players
        public async Task<ItemList<LabelList>> GetPlayerLabelsAsync(Query query = null)
        {
            _validator.ValidateQuery(query);

            var uri = $"labels/players{query}";

            return await _gameData.RequestAsync<ItemList<LabelList>>(uri);
        }
    }
}
