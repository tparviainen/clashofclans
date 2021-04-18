using System;
using System.Threading.Tasks;

namespace ClashOfClans.App.Examples
{
    public class GoldPassExamples
    {
        private readonly string token;

        public GoldPassExamples(string token)
        {
            this.token = token;
        }

        /// <summary>
        /// Get information about the current gold pass season.
        /// </summary>
        public async Task GetCurrentGoldPassSeason()
        {
            var coc = new ClashOfClansClient(token);
            var currentGoldPassSeason = await coc.GoldPass.GetCurrentGoldPassSeasonAsync();

            Console.WriteLine($"Current GoldPass season started '{currentGoldPassSeason.StartTime.ToLocalTime()}'" +
                $"and ends '{currentGoldPassSeason.EndTime.ToLocalTime()}'");
        }
    }
}
