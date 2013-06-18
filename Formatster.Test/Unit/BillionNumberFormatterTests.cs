using Formatster.Core;
using NUnit.Framework;

namespace Formatster.Tests.Unit
{
    [TestFixture]
    public class BillionNumberFormatterTests
    {
        [Test]
        public void ShouldConvertBillionWithDecimalsToDecimalThatDoesNotRoundUp() {
            // Setup
            const double numberToFormat = 12330000000.23;
            const string expectedResult = "12.3B";
            INumberFormatter formatter = new BillionNumberFormatter();

            // Test
            string result = formatter.Format(numberToFormat);

            //Verify
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ShouldConvertBillionToDecimalThatHasToRoundUp() {
            // Setup
            const double numberToFormat = 12350000000;
            const string expectedResult = "12.4B";
            INumberFormatter formatter = new BillionNumberFormatter();

            // Test
            string result = formatter.Format(numberToFormat);

            //Verify
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ShouldConvertBillionToNoDecimalNumber() {
            // Setup
            const double numberToFormat = 1000000000;
            const string expectedResult = "1B";
            INumberFormatter formatter = new BillionNumberFormatter();

            // Test
            string result = formatter.Format(numberToFormat);

            //Verify
            Assert.AreEqual(expectedResult, result);
        }
    }
}