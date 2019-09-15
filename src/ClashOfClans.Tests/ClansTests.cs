using ClashOfClans.Core;
using ClashOfClans.Models;
using ClashOfClans.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
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
            var taskList = new List<Task<Clan>>();

            // Act
            foreach (var clan in _clans.Items)
            {
                taskList.Add(_coc.Clans.GetAsync(clan.Tag));
            }

            // Assert
            foreach (var clan in await Task.WhenAll(taskList))
            {
                Assert.IsNotNull(clan);
                Trace.WriteLine($"Tag: {clan.Tag}, name: {clan.Name}, level: {clan.ClanLevel}");
            }
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
            var taskList = new List<Task<WarLog>>();

            // Act
            foreach (var clan in _clans.Items.Where(c => c.IsWarLogPublic == true))
            {
                taskList.Add(_coc.Clans.GetWarLogAsync(clan.Tag));
            }

            // Assert
            Assert.IsTrue(taskList.Any(), "Test data does not contain a clan with public war log!");

            foreach (var warLog in await Task.WhenAll(taskList))
            {
                var first = warLog.Items.FirstOrDefault();
                if (first != null)
                {
                    Trace.WriteLine($"\nClan: {first.Clan.Tag}/{first.Clan.Name}");

                    foreach (var entry in warLog.Items.Where(w => w.Opponent.Tag != null))
                    {
                        Trace.WriteLine($"-> {entry.Result} against {entry.Opponent.Tag}/{entry.Opponent.Name} @ {entry.EndTime.ToLocalTime()}");
                    }
                }
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
