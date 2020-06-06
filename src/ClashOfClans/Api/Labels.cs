using ClashOfClans.Core;
using ClashOfClans.Models;
using ClashOfClans.Search;
using System.Threading.Tasks;

#nullable enable

namespace ClashOfClans.Api
{
    internal class Labels : ILabels
    {
        private readonly IGameData _gameData;

        public Labels(IGameData gameData)
        {
            _gameData = gameData;
        }

        public Task<QueryResult<LabelList>> GetClanLabelsAsync(Query? query = default)
        {
            var request = new AutoValidatedRequest
            {
                Query = query,
                Uri = "/labels/clans"
            };

            return _gameData.QueryAsync<LabelList>(request);
        }

        public Task<QueryResult<LabelList>> GetPlayerLabelsAsync(Query? query = default)
        {
            var request = new AutoValidatedRequest
            {
                Query = query,
                Uri = "/labels/players"
            };

            return _gameData.QueryAsync<LabelList>(request);
        }
    }
}
