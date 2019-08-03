﻿using ClashOfClans.Core;
using ClashOfClans.Models;
using ClashOfClans.Search;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ClashOfClans.Tests
{
    [TestClass]
    public class TestsBase
    {
        private readonly Random _random = new Random();

        protected static SearchResult _clans;
        protected static LocationList _locations;
        protected static LeagueList _leagues;
        protected static IConfigurationRoot _config;
        protected static ClashOfClansApi _coc;

        public string PlayerTag { get => _config["playerTag"]; }
        public string ClanTag { get => _config["clanTag"]; }

        [AssemblyInitialize]
        public static async Task AssemblyInitialize(TestContext context)
        {
            try
            {
                _config = new ConfigurationBuilder()
                    .AddJsonFile("AppSettings.test.json")
                    .Build();

                AddTraceListener(_config["logPath"]);

                _coc = new ClashOfClansApi(_config["api:token"]);
                var query = new QueryClans
                {
                    MinMembers = 40,
                    MaxMembers = 40,
                    Limit = 50
                };

                _clans = await _coc.Clans.GetAsync(query);
                _locations = await _coc.Locations.GetAsync();
                _leagues = await _coc.Leagues.GetAsync();
            }
            catch (ClashOfClansException ex)
            {
                Assert.Fail($"{ex.Error}");
            }
        }

        private static void AddTraceListener(string logPath)
        {
            if (string.IsNullOrWhiteSpace(logPath))
            {
                throw new ArgumentNullException(nameof(logPath));
            }

            Directory.CreateDirectory(logPath);
            var today = DateTime.Now.ToString("yyyyMMdd");
            var logFile = Path.Combine(logPath, $"{today}-CoC.log");

            // Creates/overwrites existing file
            var stream = File.Create(logFile);
            var listener = new TextWriterTraceListener(stream);

            Trace.Listeners.Add(listener);
            Trace.AutoFlush = true;
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
