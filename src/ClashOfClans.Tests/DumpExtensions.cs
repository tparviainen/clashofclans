using ClashOfClans.Models;
using System;
using System.Linq;
using System.Text;

namespace ClashOfClans.Tests
{
    public static class DumpExtensions
    {
        public static string Dump(this Clan clan)
        {
            return $"Tag: {clan.Tag}, name: {clan.Name}, level: {clan.ClanLevel}, members: {clan.Members}";
        }

        public static string Dump(this WarLog warLog)
        {
            var sb = new StringBuilder();

            if (warLog.Items != null)
            {
                foreach (var entry in warLog.Items.Where(w => w.Opponent.Tag != null))
                {
                    sb.Append(Environment.NewLine);
                    sb.Append(entry.Dump());
                }
            }

            return sb.ToString();
        }

        public static string Dump(this CurrentWar currentWar)
        {
            var sb = new StringBuilder();
            sb.Append(Environment.NewLine);

            // When clan is not in war all the values are null
            if (currentWar.State != State.NotInWar)
            {
                var pse = PSE(currentWar.PreparationStartTime, currentWar.StartTime, currentWar.EndTime);
                sb.Append($"{currentWar.State} {pse}");
                sb.Append(Environment.NewLine);
                sb.Append($"{currentWar.Clan.Dump()}");
                sb.Append(Environment.NewLine);
                sb.Append($"{currentWar.Opponent.Dump()}");
            }
            else
            {
                sb.Append($"{State.NotInWar}");
            }

            return sb.ToString();
        }

        public static string PSE(DateTime p, DateTime s, DateTime e)
        {
            return $"P: {p.ToLocalTime()}, S: {s.ToLocalTime()}, E: {e.ToLocalTime()}";
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

        public static string Dump(this CurrentWarLeagueGroup leagueGroup)
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

            sb.Append($"Clan {clan.Tag}/{clan.Name} [{clan.Stars}☆/{clan.DestructionPercentage}%/{clan.Attacks}]");
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

            if (members.Any())
            {
                sb.Append(players);
                sb.Append(Environment.NewLine);
                foreach (var member in members)
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

            sb.Append($"{clan.Tag}/{clan.Name} [{clan.Stars}☆/{clan.DestructionPercentage}%/{clan.Attacks ?? -1}]");

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

        public static string Dump(this WarLogEntry entry)
        {
            return $"{entry.Clan.Dump()} vs {entry.Opponent.Dump()}, {entry.Result} @ {entry.EndTime.ToLocalTime()}";
        }

        public static string Dump(this ClanMemberList list)
        {
            var sb = new StringBuilder();

            if (list.Items != null)
            {
                foreach (var member in list.Items)
                {
                    sb.Append($"{member.Tag}/{member.Name}, donations {member.Donations}/{member.DonationsReceived}");
                    sb.Append($"={((member.DonationsReceived != 0) ? member.Donations/(float)member.DonationsReceived : -1)}");
                    sb.Append(Environment.NewLine);
                }
            }

            return sb.ToString();
        }
    }
}
