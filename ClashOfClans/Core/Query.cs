namespace ClashOfClans.Core
{
    public class Query
    {
        /// <summary>
        /// Limit the number of items returned in the response
        /// </summary>
        public int? Limit;

        /// <summary>
        /// Return only items that occur after this marker. After marker can
        /// be found from the response, inside the 'paging' property. Note
        /// that only after or before can be specified for a request, not both.
        /// </summary>
        public string After;

        /// <summary>
        /// Return only items that occur before this marker. Before marker can
        /// be found from the response, inside the 'paging' property. Note that
        /// only after or before can be specified for a request, not both.
        /// </summary>
        public string Before;

        public override string ToString()
        {
            var query = string.Empty;

            var fields = GetType().GetFields();

            foreach (var field in fields)
            {
                var value = field.GetValue(this);
                if (value != null)
                {
                    query += $"&{field.Name.ToLower()}={field.GetValue(this)}";
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
