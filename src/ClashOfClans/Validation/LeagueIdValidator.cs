using System;

namespace ClashOfClans.Validation
{
    internal partial class Validator
    {
        public Validator ValidateLeagueId(int? leagueId)
        {
            if (!leagueId.HasValue)
            {
                throw new ArgumentException("League identifier must not be empty");
            }

            return this;
        }
    }
}
