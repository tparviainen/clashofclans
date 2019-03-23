namespace ClashOfClans.Core
{
    public class QueryClans : Query
    {
        /// <summary>
        /// Search clans by name. If name is used as part of search query, it
        /// needs to be at least three characters long. Name search parameter
        /// is interpreted as wild card search, so it may appear anywhere in
        /// the clan name.
        /// </summary>
        public string Name;

        /// <summary>
        /// Filter by clan war frequency.
        /// </summary>
        public string WarFrequency;

        /// <summary>
        /// Filter by clan location identifier. For list of available locations,
        /// refer to getLocations operation.
        /// </summary>
        public int? LocationId;

        /// <summary>
        /// Filter by minimum amount of clan members.
        /// </summary>
        public int? MinMembers;

        /// <summary>
        /// Filter by maximum amount of clan members.
        /// </summary>
        public int? MaxMembers;

        /// <summary>
        /// Filter by minimum amount of clan points.
        /// </summary>
        public int? MinClanPoints;

        /// <summary>
        /// Filter by minimum clan level.
        /// </summary>
        public int? MinClanLevel;
    }
}
