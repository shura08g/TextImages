using System.Drawing;
using System.Collections.Generic;
//using System.Linq;

namespace TextImages
{
   // public static class ColorConverter
    public class ColorConverter
    {
        public readonly static string Black = "@";
        public readonly static string LightGray = "-";
        public readonly static string Yellow = "+";
        public readonly static string White = " ";
        public readonly static string DarkRed = "#";

        private readonly Dictionary<double, string> _brightnessMap = new Dictionary<double, string>
                {
                    {0.15, Black},
                    {0.30, DarkRed},
                    {0.50, Yellow},
                    {0.83, LightGray},
                    {1.0, White}
                };

        //public static string ConvertToAscii(Color color)
        public string ConvertToAscii(Color color)
        {
            string ascii = "";
          //  var y = Color.Yellow.GetBrightness();

            var brightness = color.GetBrightness();
            //foreach (var candidate in brightnessMap.Where(candidate => brightness <= candidate.Key))
            foreach (var candidate in _brightnessMap)
            {
                if (brightness <= candidate.Key)
                {
                    ascii = candidate.Value;
                    break;
                }
            }
            return ascii;
        }
    }
}
