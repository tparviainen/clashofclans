using System.Linq;

namespace ClashOfClans.Models
{
    public partial class LeagueList
    {
        /// <summary>
        /// Provides an access to <see cref="League"/> data for the named league.
        /// </summary>
        /// <param name="name">League name</param>
        /// <code>
        /// var coc = new ClashOfClansApi(token);
        /// var leagues = await coc.Leagues.GetAsync();
        /// var league = leagues["Legend League"];
        /// </code>
        /// <returns>League data</returns>
        public League this[string name]
        {
            get => Items?.SingleOrDefault(l => l.Name == name);
        }
    }
}
