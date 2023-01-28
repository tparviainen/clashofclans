namespace ClashOfClans.Models
{
    public class ClanCapitalRaidSeasonAttack
    {
        private int? _stars;
        private int? _destructionPercent;

        public ClanCapitalRaidSeasonAttacker Attacker { get; set; } = default!;

        public int DestructionPercent { get => _destructionPercent ?? default; set => _destructionPercent = value; }

        public int Stars { get => _stars ?? default; set => _stars = value; }
    }
}
