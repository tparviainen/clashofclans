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
            var taskList = new List<Task<CurrentWar>>();

            // Act
            foreach (var clan in _clans.Items.Where(c => c.IsWarLogPublic == true))
            {
                taskList.Add(_coc.Clans.GetCurrentWarAsync(clan.Tag));
            }

            // Assert
            Assert.IsTrue(taskList.Any(), "Test data does not contain a clan with public war log!");

            foreach (var currentWar in await Task.WhenAll(taskList))
            {
                // When clan is not in war all the values are null
                if (currentWar.State != State.NotInWar)
                {
                    Trace.WriteLine($"{currentWar.Clan.Tag} vs {currentWar.Opponent.Tag}: {currentWar.State}, " +
                        $"P:{currentWar.PreparationStartTime.ToLocalTime()}, S:{currentWar.StartTime.ToLocalTime()}, E:{currentWar.EndTime.ToLocalTime()}");
                }
            }
        }

        [TestMethod]
        public async Task RetrieveInformationAboutClansCurrentClanWarLeagueGroupAndWar()
        {
            // Arrange
            var taskList = new List<Task<CurrentWarLeagueGroup>>();

            // Act
            foreach (var clan in _clans.Items.Where(c => c.IsWarLogPublic == true))
            {
                taskList.Add(_coc.Clans.GetCurrentWarLeagueGroupAsync(clan.Tag));
            }

            try
            {
                await Task.WhenAll(taskList);
            }
            catch (ClashOfClansException)
            {
                // For clans that dont have CWL history
            }

            // Assert
            var leagueGroups = taskList.Where(t => t.Status == TaskStatus.RanToCompletion).Select(t => t.Result);
            Assert.IsTrue(leagueGroups.Any(), "Test data does not contain a clan with public CWL war log!");

            foreach (var leagueGroup in leagueGroups)
            {
                Trace.WriteLine($"{leagueGroup}");

                foreach (var round in leagueGroup.Rounds)
                {
                    var warRequests = new List<Task<ClanWarLeagueWar>>();
                    foreach (var warTag in round.WarTags)
                    {
                        warRequests.Add(_coc.Clans.GetClanWarLeaguesWarsAsync(warTag));
                    }

                    var wars = await Task.WhenAll(warRequests);
                    foreach (var war in wars)
                    {
                        Trace.WriteLine($"\n{war.Clan.Name} [{war.Clan.Stars}☆/{war.Clan.DestructionPercentage}/{war.Clan.Attacks}] vs {war.Opponent.Name} [{war.Opponent.Stars}☆/{war.Opponent.DestructionPercentage}/{war.Opponent.Attacks}]");
                        Trace.WriteLine($"Preparation: {war.PreparationStartTime.ToLocalTime()}, start: {war.StartTime.ToLocalTime()}, end: {war.EndTime.ToLocalTime()}");

                        foreach (var member in war.Clan.Members.Where(m => m.Attacks != null).OrderBy(m => m.Attacks[0].Order))
                        {
                            var attack = member.Attacks[0];
                            Trace.WriteLine($"-> {member.Name}, {attack.Stars}☆/{attack.DestructionPercentage}%");
                        }

                        foreach (var member in war.Clan.Members.Where(m => m.Attacks == null && m.BestOpponentAttack != null))
                        {
                            Trace.WriteLine($"-> {member.Name}");
                        }

                        foreach (var member in war.Opponent.Members.Where(m => m.Attacks != null).OrderBy(m => m.Attacks[0].Order))
                        {
                            var attack = member.Attacks[0];
                            Trace.WriteLine($"<- {member.Name}, {attack.Stars}☆/{attack.DestructionPercentage}%");
                        }

                        foreach (var member in war.Opponent.Members.Where(m => m.Attacks == null && m.BestOpponentAttack != null))
                        {
                            Trace.WriteLine($"<- {member.Name}");
                        }
                    }
                }
            }
        }
    }
}
