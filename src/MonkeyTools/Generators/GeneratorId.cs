using System;
namespace MonkeyTools
{
    public static partial class Generator
    {
        /// <summary>
        /// Method to generate string id with request length
        /// </summary>
        /// <param name="length">string id size</param>
        /// <returns>string id with resquest size</returns>
        public static string GetId(int length)
        {
            if (length <= 0)
                throw new ArgumentException("Length cannot be less than 1");
            return GetRandomString(length);
        }
    }
}
