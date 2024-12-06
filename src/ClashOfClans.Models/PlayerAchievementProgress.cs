namespace ClashOfClans.Models
{
    public class PlayerAchievementProgress
    {
        public string Name { get; set; } = default!;

        public int Stars { get; set; }

        public int Value { get; set; }

        public int Target { get; set; }

        public string Info { get; set; } = default!;

        public string? CompletionInfo { get; set; }

        public Village Village { get; set; }
    }
}
