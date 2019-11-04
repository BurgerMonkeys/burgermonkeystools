using System;
using System.Linq;

namespace BurgerMonkeys.Tools
{
    public static partial class Converter
    {
        /// <summary>
        /// Convert string angle formated to decimal value
        /// </summary>
        /// <param name="value">string formated 120°10'20"</param>
        /// <returns>Decimal value</returns>
        public static double AngleToDecimal(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("string is null our empty");

            bool angle = false;
            bool time = false;

            if (value.Contains("º") || value.Contains("°"))
                angle = true;
            if (value.Contains("'") || value.Contains("´") || value.Contains("`"))
                time = true;


            if (angle && time)
            {
                var at = value.Split(value.Contains('°') ? '°' : 'º');
                var a = Convert.ToInt32(at[0]);

                string[] timeArray = GetTimeArray(at[1]);
                
                var b = Convert.ToInt32(timeArray[0]);
                var c = Convert.ToInt32(timeArray[1]);

                if (c >= 60)
                {
                    b += 1;
                    c -= 60;
                }
                if (b >= 60)
                {
                    a += 1;
                    b -= 60;
                }
                return a + (b / 60d) + (c / 60d / 60d);
            }
            else if(angle && !time)
            {
                return Convert.ToDouble(value);
            }
            else if(!angle && time)
            {
                string[] timeArray = GetTimeArray(value);

                var a = 0;
                var b = Convert.ToInt32(timeArray[0]);
                var c = Convert.ToInt32(timeArray[1]);

                if (c >= 60)
                {
                    b += 1;
                    c -= 60;
                }
                if (b >= 60)
                {
                    a += 1;
                    b -= 60;
                }
                return a + (b / 60d) + (c / 60d / 60d);
            }
            else
            {
                throw new ArgumentException("Invalid string format");
            }
        }

        static string[] GetTimeArray(string value) => value.Split('\'');

        /// <summary>
        /// Method Converts a Primitive Object to Angles string
        /// </summary>
        /// <param name="value">Any object of the primitive type</param>
        /// <returns></returns>
        public static string AngleToString(this object value)
        {
            if (value == null)
                throw new ArgumentException("object null");

            try
            {
                var v = (decimal)value.ToString().AngleToDecimal();
                var isPositive = v >= 0;
                v = Math.Abs(v);
                var deg = Math.Floor(v);
                var min = Math.Floor(Math.Round((v - deg) * 60m, 2));
                var sec = Math.Round((v - deg - min / 60) * 60m * 60m, 0);
                return string.Format((isPositive ? null : "-") + "{0:00}º {1:00}' {2:00}''", deg, min, sec);
            }
            catch (Exception)
            {
                throw new ArgumentException("Cannot convert object to decimal");
            }
        }
    }
}
