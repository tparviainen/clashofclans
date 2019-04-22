using System;

namespace ClashOfClans.Validation
{
    internal partial class Validator
    {
        public Validator ValidateClanTag(string clanTag)
        {
            if (string.IsNullOrWhiteSpace(clanTag))
            {
                throw new ArgumentException("Clan tag must not be empty");
            }

            if (!clanTag.StartsWith("#"))
            {
                throw new ArgumentException("Clan tags start with hash character '#'");
            }

            return this;
        }
    }
}
