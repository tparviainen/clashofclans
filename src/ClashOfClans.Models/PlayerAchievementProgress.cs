namespace ClashOfClans.Models
{
    public class PlayerAchievementProgress
    {
        private int? _stars;
        private int? _value;
        private int? _target;
        private Village? _village;

        public string Name { get; set; } = default!;

        public int Stars { get => _stars ?? default; set => _stars = value; }

        public int Value { get => _value ?? default; set => _value = value; }

        public int Target { get => _target ?? default; set => _target = value; }

        public string Info { get; set; } = default!;

        public string? CompletionInfo { get; set; }

        public Village Village { get => _village ?? default; set => _village = value; }
    }
}
