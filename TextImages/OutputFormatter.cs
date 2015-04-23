using System;
using System.Collections.Generic;
using System.Text;


namespace TextImages
{
    public class OutputFormatter
    {
        public static string Format(List<string> array)
        {
            if (array == null) return string.Empty;

            var output = new StringBuilder();

            foreach (var line in array)
            {
                output.AppendLine(line);
            }

            return output.ToString();

          //  var preProcess = output.ToString();
          //  preProcess = preProcess.Substring(0, preProcess.Length - Environment.NewLine.Length);
          //  return preProcess;
        }
    }
}
