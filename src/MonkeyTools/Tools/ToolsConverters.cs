using System;
namespace MonkeyTools
{
    public static partial class Tools
    {
        public static int ToInt(object obj)
        {
            return Convert.ToInt32(obj);
        }

        public static bool ToBoolean(object obj)
        {
            return Convert.ToBoolean(obj);
        }

        public static decimal ToDecimal(object obj)
        {
            return Convert.ToDecimal(obj);
        }
    }
}
