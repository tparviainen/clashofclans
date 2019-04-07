namespace ClashOfClans.Models
{
    public class AchievementList
    {
        public string Name { get; set; }

        public int? Stars { get; set; }

        public int? Value { get; set; }

        public int? Target { get; set; }

        public string Info { get; set; }

        public string CompletionInfo { get; set; }

        public Village Village { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
