using ClashOfClans.Core;
using ClashOfClans.Models;
using ClashOfClans.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
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
            var limit = 10;
            var query = new QueryClans
            {
                Name = "Phoenix",
                Limit = limit,
                WarFrequency = WarFrequency.Never
            };

            // Act
            var searchResult = await _coc.Clans.GetAsync(query);

            // Assert
            Assert.IsNotNull(searchResult);
            Assert.AreEqual(limit, searchResult.Items.Count());
        }

        [TestMethod]
        [DataRow("China")]
        [DataRow("Finland")]
        [DataRow("Lesotho")]
        [DataRow("United States")]
        public async Task LoopClansFromSpecificLocation(string locationName)
        {
            // Arrange
            var count = 0;
            var location = _locations[locationName];
            var query = new QueryClans
            {
                Limit = 200,
                LocationId = location.Id
            };

            // Act
            do
            {
                var searchResult = await _coc.Clans.GetAsync(query);
                searchResult.Items.ToList().ForEach(clan => Trace.WriteLine(clan));
                query.After = searchResult.Paging.Cursors.After;
                count += searchResult.Items.Count();
            } while (query.After != null);

            // Assert
            Trace.WriteLine($"{locationName}: {count}");
            Assert.IsTrue(count != 0);
        }

        [TestMethod]
        public async Task GetClanInformation()
        {
            // Arrange
            var clanTag = GetRandom(_clans.Items).Tag;

            // Act
            var clan = await _coc.Clans.GetAsync(clanTag);
            Trace.WriteLine(clan);

            // Assert
            Assert.IsNotNull(clan);
        }

        [TestMethod]
        public async Task ListClanMembers()
        {
            // Arrange
            var clanTag = GetRandom(_clans.Items).Tag;

            // Act
            var clansMembers = await _coc.Clans.GetMembersAsync(clanTag);

            // Assert
            Assert.IsNotNull(clansMembers);
        }

        [TestMethod]
        public async Task RetrieveClansClanWarLog()
        {
            // Arrange
            var clan = GetRandom(_clans.Items.Where(c => c.IsWarLogPublic == true).ToList());

            // Act
            if (clan != null)
            {
                Trace.WriteLine(clan);

                var clanWarLog = await _coc.Clans.GetWarLogAsync(clan.Tag);
                Trace.WriteLine(clanWarLog);

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
            var clan = GetRandom(_clans.Items.Where(c => c.IsWarLogPublic == true).ToList());

            // Act
            if (clan != null)
            {
                Trace.WriteLine(clan);

                var currentWar = await _coc.Clans.GetCurrentWarAsync(clan.Tag);
                Trace.WriteLine(currentWar);

                // Assert
                Assert.IsNotNull(currentWar);
            }
        }

        [TestMethod]
        public async Task RetrieveInformationAboutClansCurrentClanWarLeagueGroupAndWar()
        {
            // Arrange

            // Act
            foreach (var clan in _clans.Items)
            {
                Trace.WriteLine(clan);

                try
                {
                    var leaguegroup = await _coc.Clans.GetCurrentWarLeagueGroupAsync(clan.Tag);
                    Trace.WriteLine(leaguegroup);

                    // WarTag="#0" round not started
                    var round = GetRandom(leaguegroup.Rounds, r => !r.WarTags.Contains("#0"));
                    var warTag = GetRandom(round.WarTags);
                    var clanWarLeagueWar = await _coc.Clans.GetClanWarLeaguesWarsAsync(warTag);

                    // Assert
                    Assert.IsNotNull(leaguegroup);
                    Assert.IsNotNull(clanWarLeagueWar);
                    break;
                }
                catch (ClashOfClansException ex)
                {
                    Trace.WriteLine(ex.Error);
                }
            }
        }
    }
}
