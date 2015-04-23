using NUnit.Framework;
using System.Drawing;
using System.Collections.Generic;

namespace TextImages.Tests
{
    [TestFixture]
    public class ColorConverterTests
    {

        public Dictionary<Color, string> TestCases = new Dictionary<Color, string>()
        {
            {Color.White, ColorConverter.White},
            {Color.Black, ColorConverter.Black},
            {Color.Yellow, ColorConverter.Yellow},
            {Color.DarkRed, ColorConverter.DarkRed},
            {Color.LightGray, ColorConverter.LightGray}
        };

        private ColorConverter _converter;

        [SetUp]
        public void SetUp()
        {
            _converter = new ColorConverter();
        }

        [Test]
        public void Convert_GivenKnownInput_ReturnsKnownOutput()
        {
            foreach (var testPair in TestCases)
            {
                var output = _converter.ConvertToAscii(testPair.Key);

                Assert.That(output, Is.EqualTo(testPair.Value), testPair.Key + " didn't convert correctly.");
            }
        }

        // или так
        [TestCase("FFFFFF", " ")]
        [TestCase("000000", "@")]
        [TestCase("FFFF00", "+")]
        [TestCase("8B0000", "#")]
        [TestCase("D3D3D3", "-")]
        public void Convert_GivenKnownInput_ReturnsKnownOutput(string hex, string expected)
        {
            var input = ColorTranslator.FromHtml("#" + hex);
            var output = _converter.ConvertToAscii(input);

            Assert.That(output, Is.EqualTo(expected));
        }
    }
}
