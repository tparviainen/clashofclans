namespace ClashOfClans.Validation
{
    internal static class Constants
    {
        /// <summary>
        /// CWL group that is in 'Preparation' state contains invalid war tags
        /// </summary>
        public const string InvalidWarTag = "#0";

        /// <summary>
        /// All tags (war tag, clan tag, player tag) starts with '#' character
        /// </summary>
        public const string TagStartChar = "#";

        /// <summary>
        /// If name is used as part of search query, it needs to be at least
        /// three characters long.
        /// </summary>
        public const int MinQueryNameLength = 3;
    }
}
