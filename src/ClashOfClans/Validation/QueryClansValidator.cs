using ClashOfClans.Search;
using System;

namespace ClashOfClans.Validation
{
    internal partial class Validator
    {
        public Validator ValidateQueryClans(QueryClans query)
        {
            if (query == null)
            {
                throw new ArgumentException("Query must not be empty");
            }

            if (query.Name != null && query.Name.Length < Constants.MinQueryNameLength)
            {
                throw new ArgumentException($"Name needs to be at least {Constants.MinQueryNameLength} characters long");
            }

            return this;
        }
    }
}
