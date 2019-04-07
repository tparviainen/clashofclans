using ClashOfClans.Models;
using System;

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

        public override string ToString()
        {
            var queryString = string.Empty;

            var properties = GetType().GetProperties();

            foreach (var property in properties)
            {
                var value = property.GetValue(this);
                if (value != null)
                {
                    var queryValue = $"{property.GetValue(this)}";

                    // Enumerations need to start with a lowercase character
                    if (Nullable.GetUnderlyingType(property.PropertyType)?.IsEnum == true)
                    {
                        queryValue = $"{char.ToLowerInvariant(queryValue[0])}{queryValue.Substring(1)}";
                    }

                    queryString += $"&{property.Name.ToLower()}={queryValue}";
                }
            }

            if (queryString.Length != 0)
            {
                return $"?{queryString.Substring(1)}";
            }

            return null;
        }
    }
}
