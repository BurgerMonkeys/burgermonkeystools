using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BurgerMonkeys.Tools
{
    public static partial class Converter
    {
        /// <summary>
        /// Method that converts any string array to a concatenated string
        /// </summary>
        /// <param name="array">String array to concat</param>
        /// <param name="separator">Concatenation Separator (Optional), by default is (,)</param>
        /// <returns>A string concat with separator ex."aaa,fff,ggg,hhh"</returns>
        public static string ArrayStringToString (this string[] array, string separator = ",")
        {
            if (array == null || !array.Any())
                throw new ArgumentException("Array null or empty");

            return string.Join (separator, array);
        }

        /// <summary>
        /// Method that concatenates any object type to string
        /// </summary>
        /// <param name="items">Items of any kind</param>
        /// <param name="valueFunction">Function used to be concatenated</param>
        /// <param name="separator">Concatenation Separator (Optional), by default is (,)</param>
        /// <param name="format">Format or not the concatenation</param>
        /// <param name="defaultValue">Default value if there is nothing in the object array</param>
        /// <param name="distinct">Do not repeat value</param>
        public static string ConcatAny<t>(this IEnumerable<t> items, Func<t, object> valueFunction, string separator = ", ", string format = null, string defaultValue = null, bool distinct = true)
        {
            if (items == null || !items.Any())
                return defaultValue;
            var itemsToConcat = (distinct ? items.Select(item => valueFunction(item)).Distinct() : items.Select(item => valueFunction(item))).ToList();
            var builder = new StringBuilder();
            foreach (var value in itemsToConcat)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(value)))
                    builder.Append(string.IsNullOrEmpty(format) ? Convert.ToString(value) + separator : string.Format("{0:" + format + "}", value) + separator);
            }
            return string.IsNullOrEmpty(builder.ToString()) ? null : builder.Remove(builder.Length - separator.Length, separator.Length).ToString();
        }
    }
}
