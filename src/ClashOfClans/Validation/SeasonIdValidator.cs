using System;

namespace ClashOfClans.Validation
{
    internal partial class Validator
    {
        public Validator ValidateSeasonId(string seasonId)
        {
            if (string.IsNullOrWhiteSpace(seasonId))
            {
                throw new ArgumentException("Season identifier must not be empty");
            }

            return this;
        }
    }
}
