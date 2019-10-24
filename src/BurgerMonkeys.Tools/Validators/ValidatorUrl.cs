namespace BurgerMonkeys.Tools
{
    public static partial class Validator
    {
        /// <summary>
        /// Mmethod to validate if the string is in valid url format
        /// </summary>
        /// <param name="url">string to validate</param>
        /// <returns>Returns if the string is in valid url format</returns>
        public static bool IsUrl(this string url)
        {
            if (string.IsNullOrEmpty(url))
                return false;
            return url.IsMatch(RegexConstants.Url);
        }
    }
}