using System;
using System.Linq;

namespace BurgerMonkeys.Tools
{
    public static partial class Validator
    {
        /// <summary>
        /// Mmethod to validate if the string is in valid email format
        /// </summary>
        /// <param name="email">string to validate</param>
        /// <returns>Returns if the string is in valid email format</returns>
        public static bool IsEmail(this string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;
            var array = email.Split(new string[] { ",", ";", " " }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim(' ', '.')).ToArray();
            foreach (var s in array)
                if (!s.IsMatch(RegexConstants.Email))
                    return false;
            return true;
        }
    }
}
