using System;
namespace MonkeyTools
{
    public static partial class Generator
    {
        /// <summary>
        /// Method to generate string for guid
        /// </summary>
        /// <returns>string for guid</returns>
        public static string GetGuid() => Guid.NewGuid().ToString();
    }
}
