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
        private Random _random = new Random();

        protected static SearchResult _clanList;
        protected static LocationList _locationList;
        protected static LeagueList _leagueList;
        protected static IConfigurationRoot _config;
        protected static ClashOfClansApi _coc;

        public string PlayerTag { get => _config["playerTag"]; }

        [AssemblyInitialize]
        public static async Task AssemblyInitialize(TestContext context)
        {
            try
            {
                _config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.test.json")
                    .Build();

                _coc = new ClashOfClansApi(_config["api:token"]);
                var query = new QueryClans
                {
                    MinMembers = 40,
                    MaxMembers = 40,
                    Limit = 50
                };

                _clanList = await _coc.Clans.GetAsync(query);
                _locationList = await _coc.Locations.GetAsync();
                _leagueList = await _coc.Leagues.GetAsync();
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
