using ClashOfClans.Core;
using ClashOfClans.Models;
using ClashOfClans.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ClashOfClans.Tests.Integration
{
    [TestClass]
    public class PlayersTests : TestsBase
    {
        [TestMethod]
        public async Task GetPlayerInformation()
        {
            // Arrange

            // Act
            foreach (var playerTag in PlayerTags)
            {
                var player = await _coc.Players.GetPlayerAsync(playerTag);

                // Assert
                Assert.IsNotNull(player);
            }
        }

        [TestMethod]
        public async Task VerifyPlayerTokenIsInvalid()
        {
            // Arrange
            var playerTag = PlayerTags.First();
            var apiToken = "12345678";

            // Act
            var response = await _coc.Players.VerifyTokenAsync(playerTag, apiToken);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Invalid, response.Status);
        }

        [TestMethod]
        public async Task GetPlayerInformationForClanMembers()
        {
            for (int i = 0; i < _clans.Count / 4; i++)
            {
                // Arrange
                var clan = GetRandom(_clans);
                var members = (ClanMemberList)await _coc.Clans.GetClanMembersAsync(clan.Tag);
                var players = new List<Task<Player>>();

                // Act
                members.ForEach(m => players.Add(_coc.Players.GetPlayerAsync(m.Tag)));

                try
                {
                    await Task.WhenAll(players);
                }
                catch (ClashOfClansException)
                {
                    // 'Not Found' players
                }

                // Assert
                Assert.IsTrue(players.Count > 0);
            }
        }

        [TestMethod]
        public async Task GetPlayerInformationForLeaguePlayers()
        {
            // Arrange
            var league = _leagues["Legend League"]!;
            var leagueSeasonList = await _coc.Leagues.GetLeagueSeasonsAsync(league.Id);
            var season = GetRandom(leagueSeasonList.Items);
            var query = new Query
            {
                Limit = 100
            };
            var seasonPlayerRankingList = (PlayerRankingList)await _coc.Leagues.GetLeagueSeasonRankingsAsync(league.Id, season.Id, query);

            // Act
            foreach (var playerTag in seasonPlayerRankingList.Select(p => p.Tag))
            {
                try
                {
                    var player = await _coc.Players.GetPlayerAsync(playerTag);

                    // Assert
                    Assert.IsNotNull(player);
                }
                catch (ClashOfClansException)
                {
                    // 'Not Found' players
                }
            }
        }

        [TestMethod]
        public async Task GetPlayerInformationInALoopWithoutThrottling()
        {
            // Arrange
            var tokenCount = 0;
            var playerTag = PlayerTags.First();
            var requestCount = 200;
            var requestsPerSecond = 50;
            var sw = new Stopwatch();
            _coc.Configure(options =>
            {
                tokenCount = options.Tokens.Count;
                Assert.IsTrue(options.MaxRequestsPerSecond == requestsPerSecond);
            });

            // Act
            try
            {
                sw.Start();
                var results = Enumerable.Range(1, requestCount).Select(i => _coc.Players.GetPlayerAsync(playerTag));
                _ = await Task.WhenAll(results);
                sw.Stop();

                Trace.WriteLine($"{requestCount} requests took {sw.ElapsedMilliseconds} ms with {tokenCount} token(s) and {requestsPerSecond} requests/second rate");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail(ex.ToString());
            }
        }
    }
}
