using System.Collections.Generic;

namespace ClashOfClans.Core
{
    /// <summary>
    /// Provides programmatic configuration for the Clash of Clans API
    /// </summary>
    public class ClashOfClansOptionsV2 : ClashOfClansOptions
    {
        public ClashOfClansOptionsV2() : base(new List<string>())
        {
            Tokens = new List<string>();
        }

        new public List<string> Tokens { get; }
    }
}
