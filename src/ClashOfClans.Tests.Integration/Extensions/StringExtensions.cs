namespace System
{
    public static class StringExtensions
    {
        /// <summary>
        /// Converts the first character of a string to uppercase
        /// </summary>
        /// <param name="text">Specifies the string to convert</param>
        /// <returns>Converted string</returns>
        public static string ToUpperFirst(this string text)
        {
            text = text.Trim();

            if (!string.IsNullOrWhiteSpace(text))
            {
                text = text.Substring(0, 1).ToUpper() + text.Substring(1);
            }

            return text;
        }
    }
}
