using System;
using System.Collections.Generic;
using System.Drawing;

namespace TextImages
{
    public class ImageTranscoder
    {

        // public static IEnumerable<string> Convert(Bitmap bitmap)
        public static List<string> ToAsciiLines(Bitmap bitmap)
        {
            
            if (bitmap == null) return new List<string>();

            var converter = new ColorConverter();

            if (bitmap.Width >= 80)
            {
                var ratio = bitmap.Width / 80.0;

                var scaleHeight = Convert.ToInt32(bitmap.Height / ratio);

                bitmap = new Bitmap(bitmap, new Size(80, scaleHeight));
            }

            var output = new List<string>();

            for (int x = 0; x < bitmap.Height; x++)
            {
                var thisLine = "";
                for (int y = 0; y < bitmap.Width; y++)
                {
                    var color = bitmap.GetPixel(y, x);

                    thisLine += converter.ConvertToAscii(color);
                }
                output.Add(thisLine);
            }

            return output;

        }
    }
}
