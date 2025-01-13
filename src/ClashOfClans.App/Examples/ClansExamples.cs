using ClashOfClans.Models;
using ClashOfClans.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClashOfClans.App.Examples;

public class ClansExamples
{
    private readonly string _token;
    private readonly string _clanTag;

    public ClansExamples(string token, string clanTag)
    {
        _token = token;
        _clanTag = clanTag;
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

        var coc = new ClashOfClansClient(_token);
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
        var coc = new ClashOfClansClient(_token);
        var clan = await coc.Clans.GetClanAsync(_clanTag);
        Console.WriteLine($"Clan '{clan.Name}' is a level {clan.ClanLevel} clan and has {clan.Members} members");
    }

    /// <summary>
    /// List clan members
    /// </summary>
    public async Task ListClanMembers()
    {
        var coc = new ClashOfClansClient(_token);
        var clanMembers = (ClanMemberList)await coc.Clans.GetClanMembersAsync(_clanTag);

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
        var coc = new ClashOfClansClient(_token);
        var clan = await coc.Clans.GetClanAsync(_clanTag);

        if (clan.IsWarLogPublic)
        {
            var warLog = await coc.Clans.GetClanWarLogAsync(_clanTag);

            foreach (var war in warLog.Items.Where(w => w.Result != null))
            {
                Console.WriteLine($"{war.Result.ToString()![0]}: {Statistics(war.Clan)} vs {Statistics(war.Opponent)}");
            }
        }

        static string Statistics(WarClan warClan) => $"{warClan.Name} [{warClan.Stars}\u2605/{warClan.DestructionPercentage}%]";
    }

    /// <summary>
    /// Retrieve information about clan's current clan war
    /// </summary>
    public async Task RetrieveInformationAboutClansCurrentClanWar()
    {
        var coc = new ClashOfClansClient(_token);
        var clanWar = await coc.Clans.GetCurrentWarAsync(_clanTag);

        Console.WriteLine($"State: {clanWar.State}, {Statistics(clanWar.Clan)} vs {Statistics(clanWar.Opponent)}");

        static string Statistics(WarClan warClan) => $"{warClan.Name} {warClan.Attacks}/{warClan.Stars}\u2605/{warClan.DestructionPercentage:0.00}%";
    }

    /// <summary>
    /// Retrieve information about clan's current clan war league (CWL) group and wars
    /// </summary>
    public async Task RetrieveInformationAboutClansCurrentClanWarLeagueGroup()
    {
        var coc = new ClashOfClansClient(_token);
        var clanWarLeagueGroup = await coc.Clans.GetClanWarLeagueGroupAsync(_clanTag);

        Console.WriteLine($"Season: {clanWarLeagueGroup.Season}, State: {clanWarLeagueGroup.State}");

        // Retrieve information about individual clan war league (CWL) war
        for (int i = 0; i < clanWarLeagueGroup.Rounds?.Count; i++)
        {
            var round = clanWarLeagueGroup.Rounds[i];
            Console.WriteLine($"Round {i + 1}.");

            var clanWarLeagueRequests = new List<Task<ClanWarLeagueWar>>();
            foreach (var warTag in round.WarTags.Where(wt => wt != "#0"))
            {
                clanWarLeagueRequests.Add(coc.Clans.GetClanWarLeagueWarAsync(warTag));
            }

            var clanWarLeagueWars = await Task.WhenAll(clanWarLeagueRequests);
            foreach (var clanWarLeagueWar in clanWarLeagueWars)
            {
                Console.WriteLine($" {clanWarLeagueWar.StartTime?.ToLocalTime()}: {Statistics(clanWarLeagueWar.Clan)} vs {Statistics(clanWarLeagueWar.Opponent)}");
            }
        }

        static string Statistics(ClanWarLeagueWarClan clan) => $"{clan.Name} [{clan.Stars}\u2605/{clan.DestructionPercentage:0.00}%/{clan.Attacks}]";
    }

    /// <summary>
    /// Retrieve clan's capital raid seasons
    /// </summary>
    public async Task RetrieveClansCapitalRaidSeasons()
    {
        var query = new Query
        {
            Limit = 1
        };
        var coc = new ClashOfClansClient(_token);
        var capitalRaidSeasons = (ClanCapitalRaidSeasons)await coc.Clans.GetCapitalRaidSeasonsAsync(_clanTag, query);

        if (capitalRaidSeasons.SingleOrDefault() is ClanCapitalRaidSeason crs)
        {
            Console.WriteLine($"CapitalTotalLoot {crs.CapitalTotalLoot}, TotalAttacks {crs.TotalAttacks}");
        }
    }
}
