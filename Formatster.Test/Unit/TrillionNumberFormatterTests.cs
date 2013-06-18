using Formatster.Core;
using NUnit.Framework;

namespace Formatster.Tests.Unit
{
    [TestFixture]
    public class TrillionNumberFormatterTests
    {
        [Test]
        public void ShouldConvertTrillionWithDecimalsToDecimalThatDoesNotRoundUp() {
            // Setup
            const double numberToFormat = 12330000000000.23;
            const string expectedResult = "12.3T";
            INumberFormatter formatter = new TrillionNumberFormatter();

            // Test
            string result = formatter.Format(numberToFormat);

            //Verify
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ShouldConvertTrillionToDecimalThatHasToRoundUp()
        {
            // Setup
            const double numberToFormat = 12350000000000;
            const string expectedResult = "12.4T";
            INumberFormatter formatter = new TrillionNumberFormatter();

            // Test
            string result = formatter.Format(numberToFormat);

            //Verify
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ShouldConvertTrillionToNoDecimalNumber()
        {
            // Setup
            const double numberToFormat = 1000000000000;
            const string expectedResult = "1T";
            INumberFormatter formatter = new TrillionNumberFormatter();

            // Test
            string result = formatter.Format(numberToFormat);

            //Verify
            Assert.AreEqual(expectedResult, result);
        }
    }
}