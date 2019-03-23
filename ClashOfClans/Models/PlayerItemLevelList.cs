namespace ClashOfClans.Models
{
    public class PlayerItemLevelList
    {
        public string Name;

        public int? Level;

        public int? MaxLevel;

        public string Village;

        public override string ToString()
        {
            return $"{Name}, Level {Level}/{MaxLevel}";
        }
    }
}