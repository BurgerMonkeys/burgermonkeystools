using System.Text.RegularExpressions;

namespace BurgerMonkeys.Tools
{
    public static partial class Validator
    {
        /// <summary>
        /// Method to validation string with pattern
        /// </summary>
        /// <param name="stringValue">String to be validate</param>
        /// <param name="pattern">Patern using to validate string</param>
        /// <returns></returns>
        public static bool IsMatch(this string stringValue, string pattern)
        {
            if (string.IsNullOrEmpty(stringValue))
                return false;
            return Regex.IsMatch(stringValue, pattern, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Method to validate the string contains one of the options
        /// </summary>
        /// <param name="stringValue">String to be validate</param>
        /// <param name="options">Items using to validade</param>
        /// <returns></returns>
        public static bool ContainsAny(this string stringValue, params string[] options)
        {
            if (stringValue == null || options == null || options.Length == 0)
                return false;

            foreach (var v in options)
                if (stringValue.Contains(v))
                    return true;
            return false;
        }
    }
}
