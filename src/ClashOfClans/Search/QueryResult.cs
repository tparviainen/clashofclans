using ClashOfClans.Models;

namespace ClashOfClans.Search
{
    /// <summary>
    /// A class representing a query result.
    ///
    /// API calls that support filtering the responses in the form of <see cref="Query"/> parameter
    /// pack the response to <see cref="QueryResult{T}"/>.
    ///
    /// If the <see cref="Paging"/> from the response is not needed the <see cref="QueryResult{T}"/>
    /// can be casted to actual response model type T via explicit cast operator.
    ///
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
