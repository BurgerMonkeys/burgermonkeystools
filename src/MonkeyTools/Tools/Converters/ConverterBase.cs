using System;

namespace MonkeyTools.Tools.Converters
{
    public static partial class Converter
    {
        public static string ToString (object obj)
        {
            return Convert.ToString (obj);
        }

        public static bool ToBoolean (object obj)
        {
            return Convert.ToBoolean (obj);
        }

        public static short ToShort (object obj)
        {
            return Convert.ToInt16 (obj);
        }

        public static int ToInt (object obj)
        {
            return Convert.ToInt32 (obj);
        }

        public static long ToLong (object obj)
        {
            return Convert.ToInt64 (obj);
        }

        public static decimal ToDecimal (object obj)
        {
            return Convert.ToDecimal (obj);
        }

        public static float ToFloat (object obj)
        {
            return Convert.ToSingle (obj);
        }

        public static double ToDouble (object obj)
        {
            return Convert.ToDouble (obj);
        }

        public static char ToChar (object obj)
        {
            return Convert.ToChar (obj);
        }
    }
}
