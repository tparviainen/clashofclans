using ClashOfClans.Models;
using ClashOfClans.Search;
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
        /// Search all clans by name and/or filtering the results using various criteria.
        /// </summary>
        public async Task SearchClans()
        {
            var query = new QueryClans
            {
                Name = "Phoenix",
                MinMembers = 40,
                MinClanLevel = 5,
                Limit = 10
            };

            var coc = new ClashOfClansApi(token);
            var clans = await coc.Clans.GetAsync(query);

            foreach (var clan in clans.Items)
            {
                Console.WriteLine($"{clan.Tag}/{clan.Name} has {clan.Members} members and is level {clan.ClanLevel} clan");
            }
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
        /// List clan members
        /// </summary>
        public async Task ListClanMembers()
        {
            var coc = new ClashOfClansApi(token);
            var clanMembers = await coc.Clans.GetMembersAsync(clanTag);

            foreach (var member in clanMembers.Items)
            {
                Console.WriteLine($"{member.ClanRank}. {member.Name}, {member.Trophies} \uD83C\uDFC6, {member.League.Name}");
            }
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
