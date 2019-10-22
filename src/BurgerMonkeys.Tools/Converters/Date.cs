using System;
using System.Globalization;

namespace BurgerMonkeys.Tools
{
    public static partial class Converter
    {
        /// <summary>
        /// Method that returns a datetimeoffset from a string
        /// </summary>
        /// <param name="stringDate">String of a date</param>
        /// <param name="stringHour"><String of a hour (Optional)</param>
        /// <returns>A datetimeoffset object</returns>
        public static DateTimeOffset StringToDateTimeOffSet (string stringDate = null, string stringHour = null)
        {
            DateTimeOffset date = DateTime.Now;

            if (string.IsNullOrWhiteSpace (stringDate))
                date = DateTimeOffset.Parse (stringDate);

            if (!string.IsNullOrWhiteSpace(stringHour))
            {
                var time = TimeSpan.Parse (stringHour);
                date.ToOffset (time);
            }

            return date;
        }

        /// <summary>
        /// Method that takes from a date the time formatted in string
        /// </summary>
        /// <param name="date">A DateTimeOffSet object</param>
        /// <returns>A string time ex.15:56</returns>
        public static string DateTimeOffsetToHour (this DateTimeOffset date)
        { 
            string format = "{0}:{1}";
            string hour = string.Format (format, date.Hour, date.Minute);
            return hour;
        }

        /// <summary>
        /// Method convert a datetimeoffset to a string formed according to culture
        /// </summary>
        /// <param name="date">A DateTimeOffSet object</param>
        /// <param name="culture">A culture string ex."pt-br"</param>
        /// <returns>Returns the date formatted according to culture. ex.10/15/2019</returns>
        public static string DateTimeOffSetToDateFormat (this DateTimeOffset date, string culture = "pt-br")
        {
            try
            {
                CultureInfo format = new CultureInfo (culture);
                return date.ToString ("d", format);
            }
            catch (Exception)
            {
                throw new ArgumentException("Culture invalid");
            }
        }
    }
}
