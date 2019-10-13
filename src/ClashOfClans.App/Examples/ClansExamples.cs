using ClashOfClans.Models;
using System;
using System.Threading.Tasks;

namespace ClashOfClans.App.Examples
{
    public class ClansExamples
    {
        private readonly string token;
        private readonly string clanTag;

        public ClansExamples(string token, string clanTag)
        {
            this.token = token;
            this.clanTag = clanTag;
        }

        /// <summary>
        /// Get information about a single clan by clan tag.
        /// </summary>
        public async Task GetClanInformation()
        {
            var coc = new ClashOfClansApi(token);
            var clan = await coc.Clans.GetAsync(clanTag);
            Console.WriteLine($"Clan '{clan.Name}' is a level {clan.ClanLevel} clan and has {clan.Members} members");
        }

        /// <summary>
        /// Retrieve clan's clan war log
        /// </summary>
        public async Task RetrieveClansClanWarLog()
        {
            var coc = new ClashOfClansApi(token);
            var clan = await coc.Clans.GetAsync(clanTag);

            if (clan.IsWarLogPublic == true)
            {
                var warLog = await coc.Clans.GetWarLogAsync(clanTag);

                foreach (var war in warLog.Items)
                {
                    Console.WriteLine($"{war.Result.ToString()[0]}: {Statistics(war.Clan)} vs {Statistics(war.Opponent)}");
                }
            }

            string Statistics(WarClan warClan) => $"{warClan.Name} [{warClan.Stars}\u2605/{warClan.DestructionPercentage}%]";
        }
    }
}
