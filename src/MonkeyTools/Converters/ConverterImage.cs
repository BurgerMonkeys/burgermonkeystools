using System;
using System.IO;
using System.Net;
using static System.Net.Mime.MediaTypeNames;

namespace MonkeyTools
{
    public static partial class Converter
    {
        /// <summary>
        /// Method converts a byte array to a base 64 image
        /// </summary>
        /// <param name="image">A byte array</param>
        /// <returns>A string base64</returns>
        public static string ByteArrayImageToBase64 (byte[] image)
        {
            if (image == null)
                return null;

            try
            {
                var image64 = Convert.ToBase64String (image);
                return image64;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Method takes an image from a URL and turn it into base64
        /// </summary>
        /// <param name="url">A valid image URL</param>
        /// <param name="toWebView">(Optional) indicates if base64 will be used in a webview</param>
        /// <returns>A string with base64 image</returns>
        public static string UrlImageToBase64 (string url, bool toWebView = false)
        {
            if (string.IsNullOrWhiteSpace (url))
                return null;

            try
            {
                var image64 = "";
                var _byte = GetImage(url);
                if (_byte == null)
                   return "URL not valid";

                image64 = !toWebView
                    ? Convert.ToBase64String(_byte, 0, _byte.Length)
                    : "data:image/jpeg;base64," + Convert.ToBase64String(_byte, 0, _byte.Length);

                return image64;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Method that returns an image byte array from a base64 Image string
        /// </summary>
        /// <param name="base64Image">A base64 image</param>
        /// <returns>A byte array image</returns>
        public static byte[] Base64ToByteArray (string base64Image)
        {
            if (string.IsNullOrWhiteSpace (base64Image))
                return null;

            try
            {
                var img = Convert.FromBase64String (base64Image);
                return img;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Method returns an array of bytes from a URL
        /// </summary>
        /// <param name="url">url image valid</param>
        /// <returns>A array of bytes</returns>

        private static byte[] GetImage (string url)
        {
            if (string.IsNullOrWhiteSpace (url))
                return null;

            byte[] buf;
            try
            {
                var myProxy = new WebProxy ();
                var req = (HttpWebRequest) WebRequest.Create (url);

                var response = (HttpWebResponse) req.GetResponse ();
                var stream = response.GetResponseStream ();

                using (var br = new BinaryReader (stream))
                {
                    var len = (int) (response.ContentLength);
                    buf = br.ReadBytes (len);
                    br.Close ();
                }

                stream.Close ();
                response.Close ();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                buf = null;
            }

            return (buf);
        }
    }
}
