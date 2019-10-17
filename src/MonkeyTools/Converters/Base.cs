using System;

namespace MonkeyTools
{
    public static partial class Converter
    {
        /// <summary>
        /// Method used to convert a obj to Bollean
        /// </summary>
        /// <param name="obj">Object any primitive</param>
        /// <returns>A boolean</returns>
        public static bool ToBoolean (object obj)
        {
            return Convert.ToBoolean(obj);
        }

        /// <summary>
        /// Method used to convert a obj to Short
        /// </summary>
        /// <param name="obj">Object any primitive</param>
        /// <returns>A short</returns>
        public static short ToShort (object obj)
        {
            return Convert.ToInt16 (obj);
        }

        /// <summary>
        /// Method used to convert a obj to Int
        /// </summary>
        /// <param name="obj">Object any primitive</param>
        /// <returns>A int</returns>
        public static int ToInt (object obj)
        {
            return Convert.ToInt32 (obj);
        }

        /// <summary>
        /// Method used to convert a obj to Long
        /// </summary>
        /// <param name="obj">Object any primitive</param>
        /// <returns>A long</returns>
        public static long ToLong (object obj)
        {
            return Convert.ToInt64 (obj);
        }

        /// <summary>
        /// Method used to convert a obj to Decimal
        /// </summary>
        /// <param name="obj">Object any primitive</param>
        /// <returns>A decimal</returns>
        public static decimal ToDecimal (object obj)
        {
            return Convert.ToDecimal (obj);
        }

        /// <summary>
        /// Method used to convert a obj to Float
        /// </summary>
        /// <param name="obj">Object any primitive</param>
        /// <returns>A float</returns>
        public static float ToFloat (object obj)
        {
            return Convert.ToSingle (obj);
        }

        /// <summary>
        /// Method used to convert a obj to Double
        /// </summary>
        /// <param name="obj">Object any primitive</param>
        /// <returns>A double</returns>
        public static double ToDouble (object obj)
        {
            return Convert.ToDouble(obj);
        }

        /// <summary>
        /// Method used to convert a obj to Char
        /// </summary>
        /// <param name="obj">Object any primitive</param>
        /// <returns>A char</returns>
        public static char ToChar (object obj)
        {
            return Convert.ToChar(obj);
        }
    }
}
