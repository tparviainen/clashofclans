using ClashOfClans.Core;
using ClashOfClans.Models;
using ClashOfClans.Search;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClashOfClans.Tests
{
    [TestClass]
    public class TestsBase
    {
        private readonly Random _random = new Random();

        protected static ClanList _clans;
        protected static LeagueList _leagues;
        protected static LocationList _locations;
        protected static IConfigurationRoot _config;
        protected static ClashOfClansApi _coc;

        public IEnumerable<string> PlayerTags { get => _config.GetSection("playerTags").GetChildren().Select(x => x.Value); }
        public IEnumerable<string> ClanTags { get => _config.GetSection("clanTags").GetChildren().Select(x => x.Value); }

        [AssemblyInitialize]
        public static async Task AssemblyInitialize(TestContext context)
        {
            try
            {
                _config = new ConfigurationBuilder()
                    .AddJsonFile("AppSettings.test.json")
                    .Build();

                _coc = new ClashOfClansApi(_config["api:token"]);
                _coc.Configure(options =>
                {
                    options.Logger = new ClashOfClansLogger(_config["logPath"]);
                    options.MaxRequestsPerSecond = 50;
                });

                var query = new QueryClans
                {
                    MinMembers = 40,
                    MinClanLevel = 10,
                    Limit = 50
                };

                _clans = await _coc.Clans.GetAsync(query);
                _leagues = await _coc.Leagues.GetAsync();
                _locations = await _coc.Locations.GetAsync();
            }
            catch (ClashOfClansException ex)
            {
                Assert.Fail($"{ex.Error}");
            }
        }

        /// <summary>
        /// Returns a random element from the given list
        /// </summary>
        protected T GetRandom<T>(IList<T> list, Func<T, bool> predicate = null) where T : class
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            if (predicate != null)
            {
                list = list.Where(predicate).ToList();
            }

            return list[_random.Next(list.Count)];
        }
    }
}
