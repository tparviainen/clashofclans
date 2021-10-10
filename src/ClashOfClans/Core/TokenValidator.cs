using System;
using System.Collections.Generic;
using System.Linq;

namespace ClashOfClans.Core
{
    internal static class TokenValidator
    {
        public static void Validate(IEnumerable<string> tokens)
        {
            if (tokens.Count() == 0)
                throw new ArgumentException("At least one API token is required");

            foreach (var token in tokens)
            {
                if (string.IsNullOrWhiteSpace(token))
                    throw new ArgumentException("Token must not be empty");
            }
        }
    }
}
