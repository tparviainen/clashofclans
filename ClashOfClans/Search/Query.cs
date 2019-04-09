using ClashOfClans.Models;

namespace ClashOfClans.Search
{
    public partial class Query
    {
        /// <summary>
        /// Limit the number of items returned in the response
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Return only items that occur after this marker. After marker can
        /// be found from the response, inside the <see cref="Paging"/> property. Note that
        /// only <see cref="After"/> or <see cref="Before"/> can be specified for a request, not both.
        /// </summary>
        public string After { get; set; }

        /// <summary>
        /// Return only items that occur before this marker. Before marker can
        /// be found from the response, inside the <see cref="Paging"/> property. Note that
        /// only <see cref="After"/> or <see cref="Before"/> can be specified for a request, not both.
        /// </summary>
        public string Before { get; set; }
    }
}
