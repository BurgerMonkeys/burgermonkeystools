using System;
using System.Text;

namespace BurgerMonkeys.Tools
{
    public  static partial class Generator
    {
        public static Random Random { get; set; }

        /// <summary>
        /// Method to generation random strings
        /// </summary>
        /// <param name="length">size of the returned string</param>
        /// <param name="strChars">characters used to generation string</param>
        /// <returns>random string generated with the length requested</returns>
        public static string GetRandomString(int length, string strChars = null)
        {
            if (string.IsNullOrEmpty(strChars))
                strChars = "abcdefghijklmnopqrstuvxwyzABCDEFGHIJKLMNOPQRSTUVXWYZ0123456789";
            Random ??= new Random();
            var sb = new StringBuilder();
            for (var x = 0; x < length; x++)
                sb.Append(strChars[Random.Next(0, strChars.Length - 1)]);
            return sb.ToString();
        }
    }
}
