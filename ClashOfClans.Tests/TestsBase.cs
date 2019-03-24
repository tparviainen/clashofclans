using ClashOfClans.Core;
using ClashOfClans.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClashOfClans.Tests
{
    [TestClass]
    public class TestsBase
    {
        public readonly string LegendLeague = "Legend League";

        private Random _random = new Random();

        /// <summary>
        /// Returns a random element from the given array
        /// </summary>
        protected T GetRandom<T>(IList<T> array) where T : class
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            var index = _random.Next(array.Count);

            return array[index];
        }

        public string Token
        {
            get
            {
                return _config["api:token"];
            }
        }

        public string PlayerTag
        {
            get
            {
                return _config["playerTag"];
            }
        }

        protected static bool _initialized;

        protected static ClanBase[] _clans;
        protected static Location[] _locations;
        protected static League[] _leagues;
        protected static IConfigurationRoot _config;

        [TestInitialize]
        public async Task TestInitialize()
        {
            if (_initialized == false)
            {
                try
                {
                    _config = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.test.json")
                        .Build();

                    var coc = new ClashOfClans(Token);
                    var query = new QueryClans
                    {
                        MinMembers = 40,
                        MaxMembers = 40,
                        Limit = 50
                    };

                    var searchResult = await coc.Clans.GetAsync(query);
                    _clans = searchResult.Items;

                    var locationList = await coc.Locations.GetAsync();
                    _locations = locationList.Items;

                    var leagueList = await coc.Leagues.GetAsync();
                    _leagues = leagueList.Items;

                    _initialized = true;

                }
                catch (ClashOfClansException ex)
                {
                    var error = ex.Error;

                    Assert.Fail($"{error.Message}, {error.Reason}");
                }
            }
        }
    }
}
