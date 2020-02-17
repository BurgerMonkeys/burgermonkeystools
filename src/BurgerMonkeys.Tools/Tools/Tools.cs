using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BurgerMonkeys.Tools
{
    public static partial class Tools
    {
        public static string RemoveAccents(this string stringValue) =>
            new string(stringValue
                .Normalize(NormalizationForm.FormD)
                .ToCharArray()
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray());
        

        public static string IgnoreCaseSensitiveAndAccents(this string stringValue) => stringValue.ToLower().RemoveAccents();

        public static string GetContentType(this string filename, bool isExtension = false)
        {
            var ext = isExtension ? filename : Path.GetExtension(filename);
            return (ext.ToLower()) switch
            {
                ".pdf" => "application/pdf",
                ".zip" => "application/zip",
                ".js" => "application/javascript",
                ".gif" => "image/gif",
                ".jpg" => "image/jpeg",
                ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".ico" => "image/x-icon",
                ".tif" => "image/tiff",
                ".tiff" => "image/tiff",
                ".eml" => "message/rfc822",
                ".mp4" => "video/mp4",
                ".mp3" => "audio/mpeg",
                ".mov" => "video/quicktime",
                ".mpg" => "video/mpeg",
                ".avi" => "video/x-msvideo",
                ".wmv" => "video/x-ms-wmv",
                ".xls" => "application/vnd.ms-excel",
                ".doc" => "application/msword",
                ".ppt" => "application/vnd.ms-powerpoint",
                ".pps" => "application/vnd.ms-powerpoint",
                ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                ".pptx" => "application/vnd.openxmlformats-officedocument.presentationml.presentation",
                ".xltx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.template",
                ".dotx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.template",
                ".ppsx" => "application/vnd.openxmlformats-officedocument.presentationml.slideshow",
                ".rtf" => "application/rtf",
                ".css" => "text/css",
                ".csv" => "text/csv",
                ".txt" => "text/plain",
                ".xml" => "text/xml",
                ".htm" => "text/html",
                ".html" => "text/html",
                _ => "application/octet-stream",
            };
        }
        
        public static string RemoveSpecialCharacters(this string text) =>
             !string.IsNullOrEmpty(text) ?
                    Regex.Replace(text, "[^\\d]+", string.Empty, RegexOptions.None) :
                    string.Empty;

        /// <summary>
        /// Method to remove all non numeric characters
        /// </summary>
        /// <param name="text">String to remove non numeric characters</param>
        /// <returns>String with only numeric characters</returns>
        public static string OnlyNumbers(this string text) =>
            !string.IsNullOrWhiteSpace(text) ?
            Regex.Replace(text, "[^0-9]", string.Empty, RegexOptions.None) :
                    string.Empty;

        /// <summary>
        /// Method to return the contrast color
        /// </summary>
        /// <param name="hexColor">Color to get contrast color</param>
        /// <returns>Hex color contrast</returns>
        public static string GetContrastColor(string hexColor)
        {
            var color = Color.FromArgb(int.Parse(hexColor.Replace("#", ""),
                         NumberStyles.AllowHexSpecifier));
            var contrast = 0.2126 * color.R + 0.7152 * color.G + 0.0722 * color.B;
            return contrast < 0.5 ? "#FFFFFF" : "#000000";
        }
    }
}
