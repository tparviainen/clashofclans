using ClashOfClans.Models;

namespace ClashOfClans.Search
{
    /// <summary>
    /// A class representing a query result.
    /// </summary>
    /// <typeparam name="T">The type of the result items</typeparam>
    public class QueryResult<T> where T : class
    {
        public T Items { get; set; }

        public Paging Paging { get; set; }
    }
}
