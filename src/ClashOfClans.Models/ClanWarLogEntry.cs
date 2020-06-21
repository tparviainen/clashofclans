using System;

namespace ClashOfClans.Models
{
    public class ClanWarLogEntry
    {
        private DateTime? _endTime;

        public Result? Result { get; set; }

        public DateTime EndTime { get => _endTime ?? default; set => _endTime = value; }

        public int? TeamSize { get; set; }

        public WarClan Clan { get; set; } = default!;

        public WarClan Opponent { get; set; } = default!;
    }
}
