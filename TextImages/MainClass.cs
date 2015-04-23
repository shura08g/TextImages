using System;
using System.Drawing;
using System.IO;


namespace TextImages
{
    class MainClass
    {
        static void Main()
        {
            string path = Environment.CurrentDirectory;
           // var duckFile = (Bitmap)Image.FromFile(path +"\\" + @"Ducky.JPG");
            var duckFile = (Bitmap)Image.FromFile(path + "\\" + @"Ducky.png");

           // duckFile = ResizeImage(duckFile, new Size(100, 100));

            var duckSized = new Bitmap(duckFile, new Size(100, 100));

            var asciiLines = ImageTranscoder.ToAsciiLines(duckSized);
            var formatted = OutputFormatter.Format(asciiLines);
           // System.Diagnostics.Debug.WriteLine(formatted);

            //string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            StreamWriter outfile = new StreamWriter(path + @"\ImageToAscii.txt", false);
            outfile.WriteLine(formatted);
        }

        public static Bitmap ResizeImage(Image imgToResize, Size size)
        {
            return (new Bitmap(imgToResize, size));
        }
    }
}
