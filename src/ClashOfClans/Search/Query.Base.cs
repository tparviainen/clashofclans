using System;
using System.Text;
using System.Net;

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
            var properties = GetType().GetProperties();

            foreach (var property in properties)
            {
                var pValue = property.GetValue(this);
                if (pValue != null)
                {
                    var qValue = pValue.ToString();

                    // Enumerations need to start with a lowercase character
                    if (Nullable.GetUnderlyingType(property.PropertyType)?.IsEnum == true)
                    {
                        qValue = $"{char.ToLowerInvariant(qValue[0])}{qValue.Substring(1)}";
                    }

                    sb.Append($"&{property.Name.ToLower()}={WebUtility.UrlEncode(qValue)}");
                }
            }

            if (sb.Length != 0)
            {
                return $"?{sb.ToString(1, sb.Length - 1)}";
            }

            return string.Empty;
        }
    }
}
