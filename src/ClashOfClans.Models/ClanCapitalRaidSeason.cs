using System;

namespace ClashOfClans.Models
{
    public class ClanCapitalRaidSeason
    {
        private ClanCapitalRaidSeasonState? _state;
        private DateTime? _startTime;
        private DateTime? _endTime;
        private int? _capitalTotalLoot;
        private int? _raidsCompleted;
        private int? _totalAttacks;
        private int? _enemyDistrictsDestroyed;
        private int? _offensiveReward;
        private int? _defensiveReward;

        public ClanCapitalRaidSeasonState State { get => _state ?? default; set => _state = value; }

        public DateTime StartTime { get => _startTime ?? default; set => _startTime = value; }

        public DateTime EndTime { get => _endTime ?? default; set => _endTime = value; }

        public int CapitalTotalLoot { get => _capitalTotalLoot ?? default; set => _capitalTotalLoot = value; }

        public int RaidsCompleted { get => _raidsCompleted ?? default; set => _raidsCompleted = value; }

        public int TotalAttacks { get => _totalAttacks ?? default; set => _totalAttacks = value; }

        public int EnemyDistrictsDestroyed { get => _enemyDistrictsDestroyed ?? default; set => _enemyDistrictsDestroyed = value; }

        public int OffensiveReward { get => _offensiveReward ?? default; set => _offensiveReward = value; }

        public int DefensiveReward { get => _defensiveReward ?? default; set => _defensiveReward = value; }

        public ClanCapitalRaidSeasonMemberList? Members { get; set; }

        public ClanCapitalRaidSeasonAttackLogList AttackLog { get; set; } = default!;

        public ClanCapitalRaidSeasonDefenseLogList DefenseLog { get; set; } = default!;
    }
}
