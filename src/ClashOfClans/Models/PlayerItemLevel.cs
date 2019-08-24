namespace ClashOfClans.Models
{
    public class PlayerItemLevel
    {
        public string Name { get; set; }

        public int? Level { get; set; }

        public int? MaxLevel { get; set; }

        public Village? Village { get; set; }

        public override string ToString()
        {
            return $"{Name}, Level {Level}/{MaxLevel}";
        }
    }
}
