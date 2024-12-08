namespace ClashOfClans.Models
{
    public class ClanWarLeagueGroup
    {
        public State State { get; set; }

        public string? Season { get; set; } = default!;

        public ClanWarLeagueClanList? Clans { get; set; } = default!;

        public ClanWarLeagueRoundList? Rounds { get; set; } = default!;
    }
}
