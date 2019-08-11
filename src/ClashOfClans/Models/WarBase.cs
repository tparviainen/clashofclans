using System;

namespace ClashOfClans.Models
{
    public abstract class WarBase
    {
        public State? State { get; set; }

        public int? TeamSize { get; set; }

        public DateTime PreparationStartTime { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
