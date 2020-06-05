using ClashOfClans.Models;

#nullable enable

namespace ClashOfClans.Search
{
    /// <summary>
    /// A class representing a query result.
    ///
    /// API calls that support filtering the responses in the form of <see cref="Query"/> parameter
    /// return the response in <see cref="QueryResult{T}"/>.
    ///
    /// If the <see cref="Paging"/> from the response is not needed the <see cref="QueryResult{T}"/>
    /// can be casted to actual response model type T via explicit cast operator.
    /// <example>
    /// <code>
    /// var coc = new ClashOfClansClient(token);
    /// var labels = (LabelList)await coc.Labels.GetClanLabelsAsync();
    /// foreach (var label in labels)
    ///     Console.WriteLine($"Id: {label.Id}, name: {label.Name}");
    /// </code>
    /// </example>
    ///
    /// </summary>
    /// <typeparam name="T">The type of the result items</typeparam>
    public class QueryResult<T> where T : class
    {
        public T Items { get; set; } = default!;

        public Paging Paging { get; set; } = default!;

        /// <summary>
        /// Allow explicit conversion from <see cref="QueryResult{T}"/> to T. The reason this is explicit
        /// is that <see cref="Paging"/> information is lost during the conversion.
        /// </summary>
        public static explicit operator T(QueryResult<T> queryResult) => queryResult.Items;
    }
}
