using Formatster.Core;
using NUnit.Framework;

namespace Formatster.Tests.Unit
{
    [TestFixture]
    public class MillionNumberFormatterTests
    {
        [Test]
        public void ShouldConvertMillionWithDecimalsToDecimalThatDoesNotRoundUp() {
            // Setup
            const double numberToFormat = 12330000.23;
            const string expectedResult = "12.3M";
            INumberFormatter formatter = new MillionNumberFormatter();

            // Test
            string result = formatter.Format(numberToFormat);

            //Verify
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ShouldConvertMillionToDecimalThatHasToRoundUp() {
            // Setup
            const double numberToFormat = 12350000;
            const string expectedResult = "12.4M";
            INumberFormatter formatter = new MillionNumberFormatter();

            // Test
            string result = formatter.Format(numberToFormat);

            //Verify
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ShouldConvertMillionToNoDecimalNumber() {
            // Setup
            const double numberToFormat = 1000000;
            const string expectedResult = "1M";
            INumberFormatter formatter = new MillionNumberFormatter();

            // Test
            string result = formatter.Format(numberToFormat);

            //Verify
            Assert.AreEqual(expectedResult, result);
        }
    }
}