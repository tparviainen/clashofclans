using System.Linq;

namespace ClashOfClans.Models
{
    public partial class LeagueList
    {
        /// <summary>
        /// Provides an access to <see cref="League"/> data for the named league.
        /// </summary>
        /// <param name="name">League name</param>
        /// <example>
        /// <code>
        /// var coc = new ClashOfClansApi(token);
        /// var leagues = (LeagueList)await coc.Leagues.GetLeaguesAsync();
        /// var league = leagues["Legend League"];
        /// </code>
        /// </example>
        /// <returns>League data</returns>
        public League this[string name]
        {
            get => this.SingleOrDefault(l => l.Name == name);
        }
    }
}
