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
        public string? After { get; set; }

        /// <summary>
        /// Return only items that occur before this marker. Before marker can
        /// be found from the response, inside the <see cref="Paging"/> property. Note that
        /// only <see cref="After"/> or <see cref="Before"/> can be specified for a request, not both.
        /// </summary>
        public string? Before { get; set; }

        /// <summary>
        /// Moves the <see cref="After"/> marker to next group of items. After successful move the
        /// client can repeat the previous API query to get next items.
        /// </summary>
        /// <returns>true if there are next items, false if there are no next items</returns>
        public bool MoveToNextItems() => SetMarkers(after: _cursors?.After);

        /// <summary>
        /// Moves the <see cref="Before"/> marker to previous group of items. After successful move
        /// the client can repeat the previous API query to get previous items.
        /// </summary>
        /// <returns>true if there are previous items, false if there are no previous items</returns>
        public bool MoveToPreviousItems() => SetMarkers(before: _cursors?.Before);

        private Cursors? _cursors;

        internal void SetCursors(Cursors cursors) => _cursors = cursors;

        private bool SetMarkers(string? before = default, string? after = default)
        {
            Before = before;
            After = after;

            if (Before != null || After != null)
                return true;

            return false;
        }
    }
}
