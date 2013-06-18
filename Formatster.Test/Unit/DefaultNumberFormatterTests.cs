using Formatster.Core;
using NUnit.Framework;

namespace Formatster.Tests.Unit
{
    [TestFixture]
    public class DefaultNumberFormatterTests
    {
        [Test]
        public void ShouldNotFormatNumberThatHasNoDecimal()
        {
            // Setup
            const double numberToFormat = 1233;
            const string expectedResult = "1233";
            INumberFormatter formatter = new DefaultNumberFormatter();

            // Test
            string result = formatter.Format(numberToFormat);

            //Verify
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ShouldNotFormatNumberThatHasADecimal() {
            // Setup
            const double numberToFormat = 1233.23;
            const string expectedResult = "1233.23";
            INumberFormatter formatter = new DefaultNumberFormatter();

            // Test
            string result = formatter.Format(numberToFormat);

            //Verify
            Assert.AreEqual(expectedResult, result);
        }
    }
}