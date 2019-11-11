namespace EloBoost.Shared.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns characters from left of specified length
        /// </summary>
        public static string Left(this string value, int length)
        {
            return value != null && value.Length > length ? value.Substring(0, length) : value;
        }

        /// <summary>
        /// Returns characters from left of specified length
        /// </summary>
        public static string Mid(this string value, int start, int length)
        {
            if (value.Length < (length + start)) length = value.Length - start;
            if (length < 0) return value;
            return value.Substring(start, length);
        }

        /// <summary>
        /// Returns characters from right of specified length
        /// </summary>
        public static string Right(this string value, int length)
        {
            return value != null && value.Length > length ? value.Substring(value.Length - length) : value;
        }
    }
}
