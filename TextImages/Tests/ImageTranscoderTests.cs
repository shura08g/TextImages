using NUnit.Framework;
using System.Drawing;

namespace TextImages.Tests
{
    [TestFixture]
    class ImageTranscoderTests
    {
        [Test]
        public void Convert_GivenNull_ReturnsEmptyString()
        {
            var output = ImageTranscoder.ToAsciiLines(null);

            Assert.That(output, Is.EqualTo(string.Empty));
        }

        [Test]
        public void Convert_GivenOneWhitePixel_ConvertToASpace()
        {
            var singlePixel = CreateBitmap(1, 1, Color.White);
            var output = ImageTranscoder.ToAsciiLines(singlePixel);

            Assert.That(output[0], Is.EqualTo(ColorConverter.White));
        }    

        [Test]
        public void Convert_GivenOneBlackPixel_ConvertToAHash()
        {
            var singlePixel = CreateBitmap(1, 1, Color.Black);
            var output = ImageTranscoder.ToAsciiLines(singlePixel);

            Assert.That(output[0], Is.EqualTo(ColorConverter.Black));
        }

        [Test]
        public void Convert_GivenOneYellowPixel_ConvertToASquare()
        {
            var singlePixel = CreateBitmap(1, 1, Color.Yellow);
            var output = ImageTranscoder.ToAsciiLines(singlePixel);

            Assert.That(output[0], Is.EqualTo(ColorConverter.Yellow));
        }

        [Test]
        public void Convert_GivenOneDarkRedPixel_ConvertToAHash()
        {
            var singlePixel = CreateBitmap(1, 1, Color.DarkRed);
            var output = ImageTranscoder.ToAsciiLines(singlePixel);

            Assert.That(output[0], Is.EqualTo(ColorConverter.DarkRed));
        }

        [Test]
        public void Convert_GivenOneLightGrayPixel_ConvertToAPlus()
        {
            var singlePixel = CreateBitmap(1, 1, Color.LightGray);
            var output = ImageTranscoder.ToAsciiLines(singlePixel);

            Assert.That(output[0], Is.EqualTo(ColorConverter.LightGray));
        }

        [Test]
        public void Convert_GivenTwoPixel_ExpectTwoSpaces()
        {
            var twoPixels = CreateBitmapWithTwoPixels(2, 1, Color.White, Color.White);
            var output = ImageTranscoder.ToAsciiLines(twoPixels);

            Assert.That(output[0], Is.EqualTo(ColorConverter.White + ColorConverter.White));
        }

        [Test]
        public void Convert_GivenTwoPixelOneWhiteOneBlack_ExpectSpaceHash()
        {
            var twoPixels = CreateBitmapWithTwoPixels(2, 1, Color.White, Color.Black);
            var output = ImageTranscoder.ToAsciiLines(twoPixels);

            Assert.That(output[0], Is.EqualTo(ColorConverter.White + ColorConverter.Black));
        }

        [Test]
        public void Convert_GivenTwoPixelOneBlackOneWhite_ExpectHashSpace()
        {
            var twoPixels = CreateBitmapWithTwoPixels(2, 1, Color.Black, Color.White);
            var output = ImageTranscoder.ToAsciiLines(twoPixels);

            Assert.That(output[0], Is.EqualTo(ColorConverter.Black + ColorConverter.White));
        }

        [Test]
        public void Convert_GivenTwoBlackPixel_ExpectHashHash()
        {
            var twoPixels = CreateBitmapWithTwoPixels(2, 1, Color.Black, Color.Black);
            var output = ImageTranscoder.ToAsciiLines(twoPixels);

            Assert.That(output[0], Is.EqualTo(ColorConverter.Black + ColorConverter.Black));
        }

        [Test]
        public void Convert_GivenBitmapTwoPixelHighOneWhiteOneBlack_ExpectWhiteNewLineBlack()
        {
            var twoPixels = CreateBitmapWithHighTwoPixels(1, 2, Color.White, Color.Black);
            var output = ImageTranscoder.ToAsciiLines(twoPixels);

            //Assert.That(output, Is.EqualTo(" \r\n#"));
            Assert.That(output[0], Is.EqualTo(ColorConverter.White));
            Assert.That(output[1], Is.EqualTo(ColorConverter.Black));
        }


        [Test]
        public void ToAsciiLines_WidthIsGreaterThen80_ResizerCalled()
        {
            var bitmap = new Bitmap(100, 1);

            var textLine = ImageTranscoder.ToAsciiLines(bitmap);

            Assert.That(textLine[0].Length, Is.EqualTo(80));
        }

        [Test]
        public void ToAsciiLines_WidthIsGreaterThen80_MaintainAsprctRatio()
        {
            var bitmap = new Bitmap(100, 200);

            var textLine = ImageTranscoder.ToAsciiLines(bitmap);

            Assert.That(textLine.Count, Is.EqualTo(160));
        }

        private static Bitmap CreateBitmap(int width, int height, Color fill)
        {
            var singlePixel = new Bitmap(width, height);
            singlePixel.SetPixel(0, 0, fill);
            return singlePixel;
        }

        private static Bitmap CreateBitmapWithTwoPixels(int width, int height, Color color1, Color color2)
        {
            var twoPixels = new Bitmap(width, height);
            twoPixels.SetPixel(0, 0, color1);
            twoPixels.SetPixel(1, 0, color2);
            return twoPixels;
        }

        private static Bitmap CreateBitmapWithHighTwoPixels(int width, int height, Color color1, Color color2)
        {
            var twoPixels = new Bitmap(width, height);
            twoPixels.SetPixel(0, 0, color1);
            twoPixels.SetPixel(0, 1, color2);
            return twoPixels;
        }
    }
}
