using System.Collections.Generic;

namespace ClashOfClans.Models
{
    public class ClanWarLeagueWarClan : Identity
    {
        private int? _clanLevel;
        private int? _attacks;
        private int? _stars;
        private float? _destructionPercentage;

        public UrlContainer BadgeUrls { get; set; } = default!;

        public int ClanLevel { get => _clanLevel ?? default; set => _clanLevel = value; }

        public int Attacks { get => _attacks ?? default; set => _attacks = value; }

        public int Stars { get => _stars ?? default; set => _stars = value; }

        public float DestructionPercentage { get => _destructionPercentage ?? default; set => _destructionPercentage = value; }

        public List<ClanWarMember> Members { get; set; } = default!;
    }
}
