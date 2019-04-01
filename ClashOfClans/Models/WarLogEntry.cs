using System;

namespace ClashOfClans.Models
{
    public class WarLogEntry
    {
        public string Result;

        public DateTime EndTime;

        public int? TeamSize;

        public WarClan Clan;

        public WarClan Opponent;
    }
}