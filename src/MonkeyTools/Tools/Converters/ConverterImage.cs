using System;
using System.IO;
using System.Net;
using static System.Net.Mime.MediaTypeNames;

namespace MonkeyTools.Tools.Converters
{
    public static partial class Converter
    {
        public static string ImageToBase64 (string Path)
        {
            if (string.IsNullOrWhiteSpace (Path))
                return null;

            try
            {
                var imageArray = File.ReadAllBytes (Path);
                var image64 = Convert.ToBase64String (imageArray);
                return image64;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static string WebImageToBase64 (string url, bool toWebView)
        {
            if (string.IsNullOrWhiteSpace (url))
                return null;

            try
            {
                var image64 = "";
                if (toWebView)
                {
                    var _byte = GetImage (url);
                    image64 = "data:image/jpeg;base64," + Convert.ToBase64String (_byte, 0, _byte.Length);
                }
                else
                {
                    var _byte = GetImage (url);
                    image64 = Convert.ToBase64String (_byte, 0, _byte.Length);
                }

                return image64;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static byte[] Base64ToByteArray (string base64)
        {
            if (string.IsNullOrWhiteSpace (base64))
                return null;

            try
            {
                var img = Convert.FromBase64String (base64);
                return img;
            }
            catch (Exception e)
            {
                return null;
            }
        }

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
                buf = null;
            }

            return (buf);
        }
    }
}
