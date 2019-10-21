using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MonkeyTools
{
    public static partial class Tools
    {
        public static bool IsMatch(string stringValue, string pattern)
        {
            if (string.IsNullOrEmpty(stringValue))
                return false;
            return Regex.IsMatch(stringValue, pattern, RegexOptions.IgnoreCase);
        }

        public static string ReplaceAll(string stringValue, List<char> oldChars, List<char> newChars)
        {
            if (string.IsNullOrEmpty(stringValue) || oldChars == null || newChars == null)
                return stringValue;
            var builder = new StringBuilder(stringValue);
            foreach (var c in oldChars)
                builder.Replace(c, newChars[oldChars.FindIndex(cc => cc == c)]);
            return builder.ToString();
        }

        public static string RemoveAccents(this string stringValue) =>
            new string(text
                .Normalize(NormalizationForm.FormD)
                .ToCharArray()
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray());
        

        public static string IgnoreCaseSensitiveAndAccents(this string stringValue) => stringValue.ToLower().RemoveAccents();

        public static string GetContentType(string filename, bool isExtension = false)
        {
            var ext = isExtension ? filename : Path.GetExtension(filename);
            switch (ext.ToLower())
            {
                case ".pdf": return "application/pdf";
                case ".zip": return "application/zip";
                case ".js": return "application/javascript";
                case ".gif": return "image/gif";
                case ".jpg": return "image/jpeg";
                case ".jpeg": return "image/jpeg";
                case ".png": return "image/png";
                case ".ico": return "image/x-icon";
                case ".tif": return "image/tiff";
                case ".tiff": return "image/tiff";
                case ".eml": return "message/rfc822";
                case ".mp4": return "video/mp4";
                case ".mp3": return "audio/mpeg";
                case ".mov": return "video/quicktime";
                case ".mpg": return "video/mpeg";
                case ".avi": return "video/x-msvideo";
                case ".wmv": return "video/x-ms-wmv";
                case ".xls": return "application/vnd.ms-excel";
                case ".doc": return "application/msword";
                case ".ppt": return "application/vnd.ms-powerpoint";
                case ".pps": return "application/vnd.ms-powerpoint";
                case ".xlsx": return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                case ".docx": return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                case ".pptx": return "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                case ".xltx": return "application/vnd.openxmlformats-officedocument.spreadsheetml.template";
                case ".dotx": return "application/vnd.openxmlformats-officedocument.wordprocessingml.template";
                case ".ppsx": return "application/vnd.openxmlformats-officedocument.presentationml.slideshow";
                case ".rtf": return "application/rtf";
                case ".css": return "text/css";
                case ".csv": return "text/csv";
                case ".txt": return "text/plain";
                case ".xml": return "text/xml";
                case ".htm": return "text/html";
                case ".html": return "text/html";
            }
            return "application/octet-stream";
        }

        public static string GetGuid() => Guid.NewGuid().ToString();

        public static string RemoveSpecialCharacters(this string text) =>
             !string.IsNullOrEmpty(text) ?
                    Regex.Replace(text, "[^\\d]+", "", RegexOptions.None) :
                    string.Empty;
    }
}
