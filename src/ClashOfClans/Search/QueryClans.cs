using ClashOfClans.Models;

namespace ClashOfClans.Search
{
    public class QueryClans : Query
    {
        /// <summary>
        /// Search clans by name. If name is used as part of search query, it
        /// needs to be at least three characters long. Name search parameter
        /// is interpreted as wild card search, so it may appear anywhere in
        /// the clan name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Filter by clan war frequency.
        /// </summary>
        public WarFrequency? WarFrequency { get; set; }

        /// <summary>
        /// Filter by clan location identifier. For list of available locations,
        /// refer to <see cref="ILocations.GetAsync(Query)" /> operation.
        /// </summary>
        public int? LocationId { get; set; }

        /// <summary>
        /// Filter by minimum number of clan members.
        /// </summary>
        public int? MinMembers { get; set; }

        /// <summary>
        /// Filter by maximum number of clan members.
        /// </summary>
        public int? MaxMembers { get; set; }

        /// <summary>
        /// Filter by minimum amount of clan points.
        /// </summary>
        public int? MinClanPoints { get; set; }

        /// <summary>
        /// Filter by minimum clan level.
        /// </summary>
        public int? MinClanLevel { get; set; }
    }
}
