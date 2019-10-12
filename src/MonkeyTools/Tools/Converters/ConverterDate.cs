using System;
using System.Globalization;

namespace MonkeyTools.Tools.Converters
{
    public static partial class Converter
    {
        public static DateTimeOffset StringDateToDateTimeOffSet (string date)
        {
            return DateTimeOffset.Parse (date);
        }
        public static DateTimeOffset StringHourToDateTimeOffSet (string hour, string date = null)
        {
            DateTimeOffset Date = new DateTimeOffset ();
            Date = DateTime.Now;

            if (string.IsNullOrWhiteSpace (date))
                Date = DateTimeOffset.Parse (date);

            var Time = TimeSpan.Parse (hour);

            Date.ToOffset (Time);

            return Date;
        }

        public static string DateTimeOffsetToStringHour (DateTimeOffset date)
        {
            string format = "{0}:{1}";
            string hour = string.Format (format, date.Hour, date.Minute);
            return hour;
        }

        public static string DateTimeOffsetToStringDateFormat (DateTimeOffset date, string culture)
        {
            CultureInfo format = new CultureInfo (culture);
            return date.ToString ("d", format);
        }
    }
}
