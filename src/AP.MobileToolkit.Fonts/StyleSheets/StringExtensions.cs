namespace AP.MobileToolkit.Fonts.StyleSheets
{
    /// <summary>
    /// Extension methods for strings
    /// </summary>
    internal static partial class StringExtensions
    {
        /// <summary>
        /// Trims whitespaces including non printing
        /// whitespaces like carriage returns, line feeds,
        /// and form feeds
        /// </summary>
        /// <param name="str">The string to trim</param>
        /// <returns></returns>
        public static string TrimWhiteSpace(this string str)
        {
            if (str == null)
            {
                return null;
            }
            char[] whiteSpace = { '\r', '\n', '\f', '\t', '\v' };
            return str.Trim(whiteSpace).Trim();
        }
    }
}
