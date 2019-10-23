using System;

namespace BurgerMonkeys.Tools
{
    public static partial class Converter
    {
        /// <summary>
        /// Method used to convert a obj to Bollean
        /// </summary>
        /// <param name="obj">Object any primitive</param>
        /// <returns>A boolean</returns>
        public static bool ToBoolean(this object obj) => Convert.ToBoolean(obj);

        /// <summary>
        /// Method used to convert a obj to Short
        /// </summary>
        /// <param name="obj">Object any primitive</param>
        /// <returns>A short</returns>
        public static short ToShort(this object obj) => Convert.ToInt16(obj);

        /// <summary>
        /// Method used to convert a obj to Int
        /// </summary>
        /// <param name="obj">Object any primitive</param>
        /// <returns>A int</returns>
        public static int ToInt(this object obj) => Convert.ToInt32(obj);

        /// <summary>
        /// Method used to convert a obj to Long
        /// </summary>
        /// <param name="obj">Object any primitive</param>
        /// <returns>A long</returns>
        public static long ToLong(this object obj) => Convert.ToInt64(obj);

        /// <summary>
        /// Method used to convert a obj to Decimal
        /// </summary>
        /// <param name="obj">Object any primitive</param>
        /// <returns>A decimal</returns>
        public static decimal ToDecimal(this object obj) => Convert.ToDecimal(obj);

        /// <summary>
        /// Method used to convert a obj to Float
        /// </summary>
        /// <param name="obj">Object any primitive</param>
        /// <returns>A float</returns>
        public static float ToFloat(this object obj) => Convert.ToSingle(obj);

        /// <summary>
        /// Method used to convert a obj to Double
        /// </summary>
        /// <param name="obj">Object any primitive</param>
        /// <returns>A double</returns>
        public static double ToDouble(this object obj) => Convert.ToDouble(obj);

        /// <summary>
        /// Method used to convert a obj to Char
        /// </summary>
        /// <param name="obj">Object any primitive</param>
        /// <returns>A char</returns>
        public static char ToChar(this object obj) => Convert.ToChar(obj);
    }
}
