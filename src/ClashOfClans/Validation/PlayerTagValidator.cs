﻿using System;

namespace ClashOfClans.Validation
{
    internal partial class Validator
    {
        public Validator ValidatePlayerTag(string playerTag)
        {
            if (string.IsNullOrWhiteSpace(playerTag))
            {
                throw new ArgumentException("Player tag must not be empty");
            }

            if (!playerTag.StartsWith(Constants.TagStartChar))
            {
                throw new ArgumentException($"Player tags start with hash character '{Constants.TagStartChar}'");
            }

            return this;
        }
    }
}
