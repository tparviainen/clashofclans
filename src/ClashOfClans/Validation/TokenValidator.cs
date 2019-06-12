using System;

namespace ClashOfClans.Validation
{
    internal partial class Validator
    {
        public Validator ValidateToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentException("Token must not be empty");
            }

            return this;
        }
    }
}
