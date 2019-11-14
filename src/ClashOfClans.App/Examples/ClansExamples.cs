using ClashOfClans.Models;
using ClashOfClans.Search;
using System;
using System.Linq;
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
            var clans = (ClanList)await coc.Clans.SearchClansAsync(query);

            foreach (var clan in clans)
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
            var clan = await coc.Clans.GetClanAsync(clanTag);
            Console.WriteLine($"Clan '{clan.Name}' is a level {clan.ClanLevel} clan and has {clan.Members} members");
        }

        /// <summary>
        /// List clan members
        /// </summary>
        public async Task ListClanMembers()
        {
            var coc = new ClashOfClansApi(token);
            var clanMembers = (ClanMemberList)await coc.Clans.GetClanMembersAsync(clanTag);

            foreach (var member in clanMembers)
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
            var clan = await coc.Clans.GetClanAsync(clanTag);

            if (clan.IsWarLogPublic == true)
            {
                var warLog = await coc.Clans.GetClanWarLogAsync(clanTag);

                foreach (var war in warLog.Items.Where(w => w.Result != null))
                {
                    Console.WriteLine($"{war.Result.ToString()[0]}: {Statistics(war.Clan)} vs {Statistics(war.Opponent)}");
                }
            }

            string Statistics(WarClan warClan) => $"{warClan.Name} [{warClan.Stars}\u2605/{warClan.DestructionPercentage}%]";
        }

        /// <summary>
        /// Retrieve information about clan's current clan war
        /// </summary>
        public async Task RetrieveInformationAboutClansCurrentClanWar()
        {
            var coc = new ClashOfClansApi(token);
            var war = await coc.Clans.GetCurrentWarAsync(clanTag);

            Console.WriteLine($"State: {war.State}, {Statistics(war.Clan)} vs {Statistics(war.Opponent)}");

            string Statistics(WarClan warClan) => $"{warClan.Name} {warClan.Attacks}/{warClan.Stars}\u2605/{warClan.DestructionPercentage:0.00}%";
        }
    }
}
