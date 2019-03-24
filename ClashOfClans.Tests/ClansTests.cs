﻿using ClashOfClans.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ClashOfClans.Tests
{
    [TestClass]
    public class ClansTests : TestsBase
    {
        [TestMethod]
        public async Task SearchClans()
        {
            // Arrange
            var clans = new Clans(Token);
            var query = new QueryClans
            {
                Name = "Phoenix",
                Limit = 10
            };

            // Act
            var clan = await clans.GetAsync(query);

            // Assert
            Assert.IsNotNull(clan);
        }

        [TestMethod]
        public async Task GetClanInformation()
        {
            // Arrange
            var clans = new Clans(Token);

            // Act
            var clanTag = GetRandom(_clans).Tag;
            var clan = await clans.GetAsync(clanTag);
            Console.WriteLine(clan);

            // Assert
            Assert.IsNotNull(clan);
        }

        [TestMethod]
        public async Task ListClanMembers()
        {
            // Arrange
            var clans = new Clans(Token);
            var clanTag = GetRandom(_clans).Tag;

            // Act
            var clansMembers = await clans.GetMembersAsync(clanTag);

            // Assert
            Assert.IsNotNull(clansMembers);
        }

        [TestMethod]
        public async Task RetrieveClansClanWarLog()
        {
            // Arrange
            var clans = new Clans(Token);

            // Act
            var clan = GetRandom(_clans.Where(c => c.IsWarLogPublic == true).ToList());
            if (clan != null)
            {
                Console.WriteLine(clan);

                var clanWarLog = await clans.GetWarLogAsync(clan.Tag);
                Console.WriteLine(clanWarLog);

                // Assert
                Assert.IsNotNull(clanWarLog);
            }
            else
            {
                Assert.Fail("Test data contains no clan with public war log!");
            }
        }

        [TestMethod]
        public async Task RetrieveInformationAboutClansCurrentClanWar()
        {
            // Arrange
            var clans = new Clans(Token);

            // Act
            var clan = GetRandom(_clans.Where(c => c.IsWarLogPublic == true).ToList());
            if (clan != null)
            {
                Console.WriteLine(clan);

                var currentWar = await clans.GetCurrentWarAsync(clan.Tag);
                Console.WriteLine(currentWar);

                // Assert
                Assert.IsNotNull(currentWar);
            }
        }

        [TestMethod]
        public async Task RetrieveInformationAboutClansCurrentClanWarLeagueGroupAndWar()
        {
            // Arrange
            var clans = new Clans(Token);

            // Act
            foreach (var clan in _clans)
            {
                Console.WriteLine(clan);

                try
                {
                    var leaguegroup = await clans.GetCurrentWarLeagueGroupAsync(clan.Tag);
                    Console.WriteLine(leaguegroup);

                    var round = GetRandom(leaguegroup.Rounds);
                    var warTag = GetRandom(round.WarTags);
                    var clanwarleagues = await clans.GetClanWarLeaguesWarsAsync(warTag);

                    // Assert
                    Assert.IsNotNull(leaguegroup);
                    Assert.IsNotNull(clanwarleagues);
                    break;
                }
                catch (ClashOfClansException)
                {
                }
            }
        }
    }
}