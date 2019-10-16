using System;
using System.Globalization;

namespace MonkeyTools
{
    public static partial class Converter
    {
        /// <summary>
        /// Method that returns a datetimeoffset from a string
        /// </summary>
        /// <param name="date">String of a date</param>
        /// <param name="hour"><String of a hour (Optional)</param>
        /// <returns>A datetimeoffset object</returns>
        public static DateTimeOffset StringToDateTimeOffSet (string date = null, string hour = null)
        {
            DateTimeOffset Date = new DateTimeOffset ();
            Date = DateTime.Now;

            if (string.IsNullOrWhiteSpace (date))
                Date = DateTimeOffset.Parse (date);
            if (!string.IsNullOrWhiteSpace(hour))
            {
                var Time = TimeSpan.Parse (hour);

                Date.ToOffset (Time);
            }

            return Date;
        }

        /// <summary>
        /// Method that takes from a date the time formatted in string
        /// </summary>
        /// <param name="date">A DateTimeOffSet object</param>
        /// <returns>A string time ex.15:56</returns>
        public static string DateTimeOffsetToHour (DateTimeOffset date)
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
        public static string DateTimeOffSetToDateFormat (DateTimeOffset date, string culture = "pt-br")
        {
            CultureInfo format = new CultureInfo (culture);
            return date.ToString ("d", format);
        }
    }
}
