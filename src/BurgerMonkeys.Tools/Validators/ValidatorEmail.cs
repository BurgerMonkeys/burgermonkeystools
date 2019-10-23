using System;
using System.Linq;

namespace BurgerMonkeys.Tools
{
    public static partial class Validator
    {
        public static bool IsEmail(this string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;
            var array = email.Split(new string[] { ",", ";", " " }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim(' ', '.')).ToArray();
            foreach (var s in array)
                if (!s.IsMatch(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                    return false;
            return true;
        }
    }
}
