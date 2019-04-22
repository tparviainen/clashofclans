using ClashOfClans.Search;
using System;

namespace ClashOfClans.Validation
{
    internal partial class Validator
    {
        public Validator ValidateQuery(Query query)
        {
            if (query != null)
            {
                if (query.After != null && query.Before != null)
                {
                    throw new ArgumentException("Only after or before can be specified for a query, not both");
                }
            }

            return this;
        }
    }
}
