namespace ClashOfClans.Models
{
    public class AchievementList
    {
        public string Name;

        public int? Stars;

        public int? Value;

        public int? Target;

        public string Info;

        public string CompletionInfo;

        public string Village;

        public override string ToString()
        {
            return Name;
        }
    }
}