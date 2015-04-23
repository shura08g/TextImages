using NUnit.Framework;
using System;
using System.Drawing;

namespace TextImages.Tests
{
    [TestFixture]
    public class AcceptanceTests
    {
        [Test]
        public void DuckYou()
        {
            string mydocpath = @"I:/prog/C#/TextImages/TextImages";
            var duckFile = (Bitmap)Image.FromFile(mydocpath + "/" + @"Ducky.png");
            //var duckFile = (Bitmap)Image.FromFile(@"I:/prog/C#/TextImages/TextImages/Ducky.png");
            var asciiLines = ImageTranscoder.ToAsciiLines(duckFile);
            var formatted = OutputFormatter.Format(asciiLines);
            System.Diagnostics.Debug.WriteLine(formatted);
        }
    }
}
