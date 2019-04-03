namespace ClashOfClans.Core
{
    public class Query
    {
        /// <summary>
        /// Limit the number of items returned in the response
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Return only items that occur after this marker. After marker can
        /// be found from the response, inside the 'paging' property. Note
        /// that only after or before can be specified for a request, not both.
        /// </summary>
        public string After { get; set; }

        /// <summary>
        /// Return only items that occur before this marker. Before marker can
        /// be found from the response, inside the 'paging' property. Note that
        /// only after or before can be specified for a request, not both.
        /// </summary>
        public string Before { get; set; }

        public override string ToString()
        {
            var query = string.Empty;

            var properties = GetType().GetProperties();

            foreach (var property in properties)
            {
                var value = property.GetValue(this);
                if (value != null)
                {
                    query += $"&{property.Name.ToLower()}={property.GetValue(this)}";
                }
            }

            if (query.Length != 0)
            {
                return $"?{query.Substring(1)}";
            }

            return null;
        }
    }
}
