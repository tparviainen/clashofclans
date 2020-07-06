namespace ClashOfClans.Models
{
    public class ClanWarLeagueGroup
    {
        private State? _state;

        public State State { get => _state ?? default; set => _state = value; }

        public string Season { get; set; } = default!;

        public ClanWarLeagueClanList Clans { get; set; } = default!;

        public ClanWarLeagueRoundList Rounds { get; set; } = default!;
    }
}
