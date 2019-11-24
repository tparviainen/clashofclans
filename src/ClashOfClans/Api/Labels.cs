using ClashOfClans.Core;
using ClashOfClans.Models;
using ClashOfClans.Search;
using System.Threading.Tasks;

namespace ClashOfClans.Api
{
    internal class Labels : ILabels
    {
        private readonly IGameData _gameData;

        public Labels(IGameData gameData)
        {
            _gameData = gameData;
        }

        public async Task<QueryResult<LabelList>> GetClanLabelsAsync(Query query = null)
        {
            var request = new AutoValidatedRequest
            {
                Query = query,
                Uri = "/labels/clans"
            };

            return await _gameData.RequestAsync<QueryResult<LabelList>>(request);
        }

        public async Task<QueryResult<LabelList>> GetPlayerLabelsAsync(Query query = null)
        {
            var request = new AutoValidatedRequest
            {
                Query = query,
                Uri = "/labels/players"
            };

            return await _gameData.RequestAsync<QueryResult<LabelList>>(request);
        }
    }
}
