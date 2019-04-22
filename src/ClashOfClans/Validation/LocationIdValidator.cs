using System;

namespace ClashOfClans.Validation
{
    internal partial class Validator
    {
        public Validator ValidateLocationId(int? locationId)
        {
            if (!locationId.HasValue)
            {
                throw new ArgumentException("Location identifier must not be empty");
            }

            return this;
        }
    }
}
