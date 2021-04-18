using System;

namespace ClashOfClans.Models
{
    public class GoldPassSeason
    {
        private DateTime? _startTime;
        private DateTime? _endTime;

        public DateTime StartTime { get => _startTime ?? default; set => _startTime = value; }

        public DateTime EndTime { get => _endTime ?? default; set => _endTime = value; }
    }
}
