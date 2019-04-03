namespace ClashOfClans.Models
{
    public class PlayerItemLevelList
    {
        public string Name { get; set; }

        public int? Level { get; set; }

        public int? MaxLevel { get; set; }

        public string Village { get; set; }

        public override string ToString()
        {
            return $"{Name}, Level {Level}/{MaxLevel}";
        }
    }
}
