using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonkeyTools.Tools.Converters
{
    public static partial class Converter
    {
        public static string ArrayStringToStringConcat (string[] words, string separator = null)
        {
            return string.Join (string.IsNullOrEmpty (separator) ? "," : separator, words);
        }

        public static string ConcatAny<t>(this IEnumerable<t> items, Func<t, object> valueFunction, string separator = ", ", string format = null, string defaultValue = null, bool distinct = true)
        {
            if (items == null || !items.Any())
                return defaultValue;
            var newlst = (distinct ? items.Select(item => valueFunction(item)).Distinct() : items.Select(item => valueFunction(item))).ToList();
            var str = new StringBuilder();
            foreach (var value in newlst)
            {
                var valuestr = Convert.ToString(value);
                if (!string.IsNullOrEmpty(valuestr))
                    str.Append(string.IsNullOrEmpty(format) ? valuestr + separator : string.Format("{0:" + format + "}", value) + separator);
            }
            return string.IsNullOrEmpty(str.ToString()) ? null : str.Remove(str.Length - separator.Length, separator.Length).ToString();
        }
    }
}
