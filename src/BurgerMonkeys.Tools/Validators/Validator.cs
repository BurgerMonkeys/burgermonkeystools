using System.Text.RegularExpressions;

namespace BurgerMonkeys.Tools
{
    public static partial class Validator
    {
        public static bool IsMatch(this string stringValue, string pattern)
        {
            if (string.IsNullOrEmpty(stringValue))
                return false;
            return Regex.IsMatch(stringValue, pattern, RegexOptions.IgnoreCase);
        }
    }
}
