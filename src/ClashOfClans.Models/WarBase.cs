using System;

namespace ClashOfClans.Models
{
    public abstract class WarBase
    {
        private DateTime? _preparationStartTime;
        private DateTime? _startTime;
        private DateTime? _endTime;

        public State? State { get; set; }

        public int? TeamSize { get; set; }

        public DateTime PreparationStartTime { get => _preparationStartTime ?? default; set => _preparationStartTime = value; }

        public DateTime StartTime { get => _startTime ?? default; set => _startTime = value; }

        public DateTime EndTime { get => _endTime ?? default; set => _endTime = value; }
    }
}
