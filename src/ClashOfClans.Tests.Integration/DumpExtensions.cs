using ClashOfClans.Models;
using System;
using System.Linq;
using System.Text;

namespace ClashOfClans.Tests.Integration
{
    public static class DumpExtensions
    {
        public static string Dump(this Label label) => $"Id: {label.Id}, name: {label.Name}";

        public static string Dump(this Clan clan)
        {
            return $"Tag: {clan.Tag}, name: {clan.Name}, level: {clan.ClanLevel}, members: {clan.Members}";
        }

        public static string Dump(this ClanWarLog warLog)
        {
            var sb = new StringBuilder();

            if (warLog != null)
            {
                foreach (var entry in warLog.Where(w => w.Opponent.Tag != null))
                {
                    sb.Append(Environment.NewLine);
                    sb.Append(entry.Dump());
                }
            }

            return sb.ToString();
        }

        public static string Dump(this ClanWar clanWar)
        {
            var sb = new StringBuilder();
            sb.Append(Environment.NewLine);

            // When clan is not in war all the values are null
            if (clanWar.State != State.NotInWar)
            {
                var pse = PSE(clanWar.PreparationStartTime, clanWar.StartTime, clanWar.EndTime);
                sb.Append($"{clanWar.State} {pse}");
                sb.Append(Environment.NewLine);
                sb.Append($"{clanWar.Clan.Dump()}");
                sb.Append(Environment.NewLine);
                sb.Append($"{clanWar.Opponent.Dump()}");
            }
            else
            {
                sb.Append($"{State.NotInWar}");
            }

            return sb.ToString();
        }

        public static string PSE(DateTime? p, DateTime? s, DateTime? e)
        {
            return $"P: {p?.ToLocalTime()}, S: {s?.ToLocalTime()}, E: {e?.ToLocalTime()}";
        }

        public static string Dump(this ClanWarLeagueWar war)
        {
            var sb = new StringBuilder();

            sb.Append(PSE(war.PreparationStartTime, war.StartTime, war.EndTime));
            sb.Append(Environment.NewLine);
            sb.Append(war.Clan.Dump());
            sb.Append(war.Opponent.Dump());

            return sb.ToString();
        }

        public static string Dump(this ClanWarMember member)
        {
            var sb = new StringBuilder();

            sb.Append($"{member.MapPosition}. {member.Tag}/{member.Name}");

            if (member.Attacks != null)
            {
                foreach (var attack in member.Attacks.OrderBy(a => a.Order))
                {
                    sb.Append($", {attack.Dump()}");
                }
            }

            return sb.ToString();
        }

        public static string Dump(this ClanWarLeagueGroup leagueGroup)
        {
            return $"CWL group: state '{leagueGroup.State}', season '{leagueGroup.Season}'";
        }

        public static string Dump(this ClanWarAttack attack)
        {
            return $"{attack.Stars}☆/{attack.DestructionPercentage}% vs {attack.DefenderTag}";
        }

        public static string Dump(this ClanWarLeagueWarClan clan)
        {
            var sb = new StringBuilder();

            sb.Append($"Clan {clan.Tag}/{clan.Name} [{clan.Stars}☆/{clan.DestructionPercentage:0.00}%/{clan.Attacks}]");
            sb.Append(Environment.NewLine);

            var members = clan.Members.Where(m => m.Attacks != null || m.BestOpponentAttack != null).OrderBy(m => m.MapPosition);
            sb.Append(Dump("InWar", members));

            members = clan.Members.Where(m => m.Attacks == null && m.BestOpponentAttack == null).OrderBy(m => m.MapPosition);
            sb.Append(Dump("Roster", members));

            return sb.ToString();
        }

        private static string Dump(string players, IOrderedEnumerable<ClanWarMember> members)
        {
            var sb = new StringBuilder();
            var membersArray = members.ToArray();

            if (membersArray.Length != 0)
            {
                sb.Append(players);
                sb.Append(Environment.NewLine);
                foreach (var member in membersArray)
                {
                    sb.Append(member.Dump());
                    sb.Append(Environment.NewLine);
                }
            }

            return sb.ToString();
        }

        public static string Dump(this WarClan clan)
        {
            var sb = new StringBuilder();

            sb.Append($"{clan.Tag}/{clan.Name} [{clan.Stars}☆/{clan.DestructionPercentage:0.00}%/{clan.Attacks ?? -1}]");

            if (clan.Members != null)
            {
                foreach (var member in clan.Members.OrderBy(m => m.MapPosition))
                {
                    sb.Append(Environment.NewLine);
                    sb.Append(member.Dump());
                }
            }

            return sb.ToString();
        }

        public static string Dump(this ClanWarLogEntry entry)
        {
            return $"{entry.Clan.Dump()} vs {entry.Opponent.Dump()}, {entry.Result} @ {entry.EndTime.ToLocalTime()}";
        }

        public static string Dump(this ClanMemberList list)
        {
            var sb = new StringBuilder();

            if (list != null)
            {
                foreach (var member in list)
                {
                    int donations = member.Donations;
                    int donationsReceived = member.DonationsReceived;

                    sb.Append($"{member.Tag}/{member.Name}, donations {donations}/{donationsReceived}");
                    sb.Append($"={((donationsReceived != 0) ? donations / (float)donationsReceived : -1)}");
                    sb.Append(Environment.NewLine);
                }
            }

            return sb.ToString();
        }

        public static string Dump(this Player player)
        {
            var sb = new StringBuilder();

            sb.Append($"{player.Tag}/{player.Name}, TH {player.TownHallLevel}, trophies {player.Trophies}");

            return sb.ToString();
        }
    }
}
