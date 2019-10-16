using System;
namespace MonkeyTools
{
    public static partial class Converter
    {
        /// <summary>
        /// Method converts time to angle
        /// </summary>
        /// <param name="hours">hours value</param>
        /// <param name="minutes">minutes value</param>
        /// <param name="seconds">seconds value</param>
        /// <returns>An analog clock angle</returns>

        public static Double AngleToDecimal(Object hours, Object minutes, Object seconds)
        {
            var n1 = Convert.ToInt32(hours);
            var n2 = Convert.ToInt32(minutes);
            var n3 = Convert.ToInt32(seconds);
            if (n3 >= 60)
            {
                n2 += 1;
                n3 -= 60;
            }
            if (n2 >= 60)
            {
                n1 += 1;
                n2 -= 60;
            }
            return n1 + (n2 / 60d) + (n3 / 60d / 60d);
        }

        /// <summary>
        /// Method Converts a Primitive Object to Angles string
        /// </summary>
        /// <param name="value">Any object of the primitive type</param>
        /// <returns></returns>
        public static string AngleToString(Object value)
        {
            if (value == null)
                return null;

            var v = Convert.ToDecimal(value);
            var isPositive = v >= 0;
            v = Math.Abs(v);
            var deg = Math.Floor(v);
            var min = Math.Floor(Math.Round((v - deg) * 60m, 2));
            var sec = Math.Round((v - deg - min / 60) * 60m * 60m, 0);
            return string.Format((isPositive ? null : "-") + "{0:00}º {1:00}' {2:00}''", deg, min, sec);
        }
    }
}
