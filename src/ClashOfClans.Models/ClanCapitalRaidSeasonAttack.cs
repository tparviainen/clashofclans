namespace ClashOfClans.Models
{
    public class ClanCapitalRaidSeasonAttack
    {
        private int? _destructionPercent;

        public ClanCapitalRaidSeasonAttacker Attacker { get; set; } = default!;

        public int DestructionPercent { get => _destructionPercent ?? default; set => _destructionPercent = value; }
    }
}
