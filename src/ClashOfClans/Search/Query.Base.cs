using System;

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
