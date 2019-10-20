﻿using ClashOfClans.Core;
using ClashOfClans.Models;
using ClashOfClans.Search;
using ClashOfClans.Validation;
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
            var searchResult = await _coc.Clans.SearchClansAsync(query);

            // Assert
            Assert.IsNotNull(searchResult);
            Assert.AreEqual(limit, searchResult.Items.Count);
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
                var searchResult = await _coc.Clans.SearchClansAsync(query);
                searchResult.Items.ToList().ForEach(clan =>
                {
                    Assert.AreEqual(locationName, clan.Location.Name);
                    Trace.WriteLine(clan);
                });

                query.After = searchResult.Paging.Cursors.After;
                count += searchResult.Items.Count;
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
            var clanTags = _clans.Items.Select(c => c.Tag).ToList();
            clanTags.AddRange(ClanTags);

            // Act
            foreach (var clanTag in clanTags)
            {
                taskList.Add(_coc.Clans.GetClanAsync(clanTag));
            }

            // Assert
            foreach (var clan in await Task.WhenAll(taskList))
            {
                Assert.IsNotNull(clan);
                Trace.WriteLine(clan.Dump());
            }
        }

        [TestMethod]
        public async Task ListClanMembers()
        {
            // Arrange
            var taskList = new List<Task<ClanMemberList>>();

            // Act
            foreach (var clanTag in ClanTags.Append(GetRandom(_clans.Items).Tag))
            {
                taskList.Add(_coc.Clans.GetClanMembersAsync(clanTag));
            }

            foreach (var memberList in await Task.WhenAll(taskList))
            {
                // Assert
                Assert.IsNotNull(memberList);
                Trace.WriteLine(memberList.Dump());
            }
        }

        [TestMethod]
        public async Task RetrieveClansClanWarLog()
        {
            // Arrange
            var taskList = new List<Task<ClanWarLog>>();

            // Act
            foreach (var clan in _clans.Items.Where(c => c.IsWarLogPublic == true))
            {
                taskList.Add(_coc.Clans.GetClanWarLogAsync(clan.Tag));
            }

            // Assert
            Assert.IsTrue(taskList.Any(), "Test data does not contain a clan with public war log!");

            foreach (var warLog in await Task.WhenAll(taskList))
            {
                Assert.IsNotNull(warLog);
                Trace.WriteLine(warLog.Dump());
            }
        }

        [TestMethod]
        public async Task RetrieveInformationAboutClansCurrentClanWar()
        {
            // Arrange
            var taskList = new List<Task<ClanWar>>();
            var clanTags = _clans.Items.Where(c => c.IsWarLogPublic == true).Select(c => c.Tag).ToList();

            foreach (var clanTag in ClanTags)
            {
                var clan = await _coc.Clans.GetClanAsync(clanTag);
                if (clan.IsWarLogPublic == true)
                    clanTags.Add(clan.Tag);
            }

            // Act
            foreach (var clanTag in clanTags)
            {
                taskList.Add(_coc.Clans.GetCurrentWarAsync(clanTag));
            }

            // Assert
            Assert.IsTrue(taskList.Any(), "Test data does not contain a clan with public war log!");

            foreach (var currentWar in await Task.WhenAll(taskList))
            {
                Assert.IsNotNull(currentWar);
                Trace.WriteLine(currentWar.Dump());
            }
        }

        [TestMethod]
        public async Task RetrieveInformationAboutClansCurrentClanWarLeagueGroupAndWar()
        {
            // Arrange
            var taskList = new List<Task<ClanWarLeagueGroup>>();
            var clanTags = _clans.Items.Where(c => c.IsWarLogPublic == true).Select(c => c.Tag).ToList();
            clanTags.AddRange(ClanTags);

            // Act
            foreach (var clanTag in clanTags)
            {
                taskList.Add(_coc.Clans.GetClanWarLeagueGroupAsync(clanTag));
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
                Assert.IsNotNull(leagueGroup);
                Trace.WriteLine(leagueGroup.Dump());

                foreach (var round in leagueGroup.Rounds)
                {
                    var warRequests = new List<Task<ClanWarLeagueWar>>();
                    foreach (var warTag in round.WarTags.Where(wt => wt != Constants.InvalidWarTag))
                    {
                        warRequests.Add(_coc.Clans.GetClanWarLeagueWarAsync(warTag));
                    }

                    var wars = await Task.WhenAll(warRequests);
                    foreach (var war in wars)
                    {
                        Assert.IsNotNull(war);
                        Trace.WriteLine(war.Dump());
                    }
                }
            }
        }
    }
}
