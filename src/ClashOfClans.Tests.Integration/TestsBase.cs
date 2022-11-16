using ClashOfClans.Core;
using ClashOfClans.Models;
using ClashOfClans.Search;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClashOfClans.Tests.Integration
{
    [TestClass]
    public class TestsBase
    {
        private readonly Random _random = new();
        protected static ClanList _clans = default!;
        protected static LeagueList _leagues = default!;
        protected static LocationList _locations = default!;
        protected static WarLeagueList _warLeagues = default!;
        protected static IConfigurationRoot _config = default!;
        protected static ClashOfClansClient _coc = default!;

        public static IEnumerable<string> PlayerTags { get => _config.GetValues("playerTags"); }
        public static IEnumerable<string> ClanTags { get => _config.GetValues("clanTags"); }

        [AssemblyInitialize]
        public static async Task AssemblyInitialize(TestContext _)
        {
            try
            {
                _config = new ConfigurationBuilder()
                    .AddJsonFile("AppSettings.test.json")
                    .Build();

                _coc = new ClashOfClansClient(_config.GetValues("api:tokens").ToArray());
                _coc.Configure(options =>
                {
                    options.Logger = new ClashOfClansLogger(_config.GetValue("logPath"));
                    options.MaxRequestsPerSecond = 50;
                });

                var query = new QueryClans
                {
                    MinMembers = 40,
                    MinClanLevel = 10,
                    Limit = 50
                };

                _clans = (ClanList)await _coc.Clans.SearchClansAsync(query);
                _leagues = (LeagueList)await _coc.Leagues.GetLeaguesAsync();
                _locations = (LocationList)await _coc.Locations.GetLocationsAsync();
                _warLeagues = (WarLeagueList)await _coc.Leagues.GetWarLeaguesAsync();
            }
            catch (ClashOfClansException ex)
            {
                var error = ex.Error;
                Assert.Fail($"{error.Reason}: {error.Message}");
            }
        }

        /// <summary>
        /// Returns a random element from the given list
        /// </summary>
        protected T GetRandom<T>(IList<T> list, Func<T, bool>? predicate = default) where T : class
        {
            if (predicate != null)
                list = list.Where(predicate).ToList();

            return list[_random.Next(list.Count)];
        }
    }
}
