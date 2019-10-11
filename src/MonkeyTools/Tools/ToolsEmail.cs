using System;
using System.Linq;

namespace MonkeyTools
{
    public static partial class Tools
    {
        public static bool IsEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;
            var array = email.Split(new string[] { ",", ";", " " }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim(' ', '.')).ToArray();
            foreach (var s in array)
                if (!IsMatch(s, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                    return false;
            return true;
        }
    }
}
