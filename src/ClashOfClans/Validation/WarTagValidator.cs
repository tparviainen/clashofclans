using System;

namespace ClashOfClans.Validation
{
    internal partial class Validator
    {
        public Validator ValidateWarTag(string warTag)
        {
            if (string.IsNullOrWhiteSpace(warTag))
            {
                throw new ArgumentException("War tag must not be empty");
            }

            if (warTag == "#0")
            {
                throw new ArgumentException("War tag is not valid");
            }

            return this;
        }
    }
}
