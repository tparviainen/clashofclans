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

        /// <summary>
        /// Allow explicit conversion from <see cref="QueryResult{T}"/> to T. The reason this is explicit
        /// is that <see cref="Paging"/> information is lost during the conversion.
        /// </summary>
        public static explicit operator T(QueryResult<T> queryResult) => queryResult.Items;
    }
}
