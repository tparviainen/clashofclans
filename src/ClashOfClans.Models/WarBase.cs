using System;

namespace ClashOfClans.Models
{
    public abstract class WarBase
    {
        private DateTime? _preparationStartTime;
        private DateTime? _startTime;
        private DateTime? _endTime;
        private State? _state;
        private int? _teamSize;

        public State State { get => _state ?? default; set => _state = value; }

        public int TeamSize { get => _teamSize ?? default; set => _teamSize = value; }

        public DateTime PreparationStartTime { get => _preparationStartTime ?? default; set => _preparationStartTime = value; }

        public DateTime StartTime { get => _startTime ?? default; set => _startTime = value; }

        public DateTime EndTime { get => _endTime ?? default; set => _endTime = value; }
    }
}
