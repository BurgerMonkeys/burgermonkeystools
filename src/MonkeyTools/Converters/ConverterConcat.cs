using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonkeyTools
{
    public static partial class Converter
    {
        /// <summary>
        /// Method that converts any string array to a concatenated string
        /// </summary>
        /// <param name="array">String array to concat</param>
        /// <param name="separator">Concatenation Separator (Optional), by default is (,)</param>
        /// <returns>A string concat with separator ex."aaa,fff,ggg,hhh"</returns>
        public static string ArrayStringToString (string[] array, string separator = ",")
        {
            return string.Join (separator, array);
        }

        /// <summary>
        /// Method that concatenates any object type to string
        /// </summary>
        /// <typeparam name="t"></typeparam>
        /// <param name="items">Items of any kind</param>
        /// <param name="valueFunction"></param>
        /// <param name="separator">Concatenation Separator (Optional), by default is (,)</param>
        /// <param name="format"></param>
        /// <param name="defaultValue">Default value if there is nothing in the object array</param>
        /// <param name="distinct"></param>
        /// <returns></returns>
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
