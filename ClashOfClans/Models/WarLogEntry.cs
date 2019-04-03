﻿using System;

namespace ClashOfClans.Models
{
    public class WarLogEntry
    {
        public string Result { get; set; }

        public DateTime EndTime { get; set; }

        public int? TeamSize { get; set; }

        public WarClan Clan { get; set; }

        public WarClan Opponent { get; set; }
    }
}
