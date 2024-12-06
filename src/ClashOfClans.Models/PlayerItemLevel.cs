namespace ClashOfClans.Models
{
    public class PlayerItemLevel
    {
        public string Name { get; set; } = default!;

        public int Level { get; set; }

        public int MaxLevel { get; set; }

        public Village Village { get; set; }

        public bool? SuperTroopIsActive { get; set; }

        public PlayerItemLevelList? Equipment { get; set; }
    }
}
