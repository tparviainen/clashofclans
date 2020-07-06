using System;

namespace ClashOfClans.Models
{
    public class ClanWarLogEntry
    {
        private DateTime? _endTime;
        private int? _teamSize;

        public Result? Result { get; set; }

        public DateTime EndTime { get => _endTime ?? default; set => _endTime = value; }

        public int TeamSize { get => _teamSize ?? default; set => _teamSize = value; }

        public WarClan Clan { get; set; } = default!;

        public WarClan Opponent { get; set; } = default!;
    }
}
