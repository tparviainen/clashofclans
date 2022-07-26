using System.Text;

namespace ClashOfClans.Search
{
    public partial class Query
    {
        /// <summary>
        /// Returns the query string for the Clash of Clans API.
        /// </summary>
        /// <returns>Query string</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            if (this is QueryClans qc)
            {
                sb.Append(qc.ToQueryString());
            }

            // Always an instance of Query that should be appended
            sb.Append(this.ToQueryString());

            if (sb.Length != 0)
                return $"?{sb.ToString(1, sb.Length - 1)}";

            return string.Empty;
        }
    }
}
