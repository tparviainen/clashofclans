namespace ClashOfClans.Models
{
    public class PlayerItemLevel
    {
        private int? _level;
        private int? _maxLevel;
        private Village? _village;

        public string Name { get; set; } = default!;

        public int Level { get => _level ?? default; set => _level = value; }

        public int MaxLevel { get => _maxLevel ?? default; set => _maxLevel = value; }

        public Village Village { get => _village ?? default; set => _village = value; }

        public bool? SuperTroopIsActive { get; set; }

        public PlayerItemLevelList? Equipment { get; set; }
    }
}
