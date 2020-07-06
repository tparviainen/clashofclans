namespace ClashOfClans.Models
{
    public class ClanWarAttack
    {
        private int? _stars;
        private int? _destructionPercentage;
        private int? _order;

        public string AttackerTag { get; set; } = default!;

        public string DefenderTag { get; set; } = default!;

        public int Stars { get => _stars ?? default; set => _stars = value; }

        public int DestructionPercentage { get => _destructionPercentage ?? default; set => _destructionPercentage = value; }

        public int Order { get => _order ?? default; set => _order = value; }
    }
}
