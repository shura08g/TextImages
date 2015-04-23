using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TextImages.Tests
{
    [TestFixture]
    public class OutputFormatterTests
    {
        [Test]
        public void Format_GivenSingleRow_ReturnsStringFromList()
        {
            var list = new List<string>() { "A" };

            var output = OutputFormatter.Format(list);

            Assert.That(output, Is.EqualTo("A" + Environment.NewLine));
        }

        [Test]
        public void Format_GivenMultleRows_ReturnsCorrectString()
        {
            var list = new List<string>() { "A", "B" };

            var output = OutputFormatter.Format(list);

            // Assert.That(output, Is.EqualTo("A\r\nB"));
            Assert.That(output, Is.EqualTo("A" + Environment.NewLine + "B" + Environment.NewLine));
        }

        [Test]
        public void Format_GivenNullList_ReturnsEmptyString()
        {
            var output = OutputFormatter.Format(null);

            Assert.That(output, Is.EqualTo(string.Empty));
        }
    }
}
