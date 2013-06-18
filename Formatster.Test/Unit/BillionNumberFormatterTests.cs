using Formatster.Core;
using NUnit.Framework;

namespace Formatster.Tests.Unit
{
    [TestFixture]
    public class BillionNumberFormatterTests
    {
        [Test]
        public void ShouldConvertBillionToDecimalThatHasToRoundUp()
        {
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
        public void ShouldConvertBillionToNoDecimalNumber()
        {
            // Setup
            const double numberToFormat = 1000000000;
            const string expectedResult = "1B";
            INumberFormatter formatter = new BillionNumberFormatter();

            // Test
            string result = formatter.Format(numberToFormat);

            //Verify
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ShouldConvertBillionWithDecimalsToDecimalThatDoesNotRoundUp()
        {
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
        public void ShouldBeAbleToConvertANumberThatInTheBillions() {
            // Setup
            const double numberToFormat = 1000000000;
            INumberFormatter formatter = new BillionNumberFormatter();

            // Test
            bool result = formatter.CanFormat(numberToFormat);

            //Verify
            Assert.AreEqual(true, result);
        }

        [Test]
        public void ShouldNotAbleToConvertNumberThatIsGreaterThanOrEqualToATrillion() {
            // Setup
            const double numberToFormat = 1000000000000;
            INumberFormatter formatter = new BillionNumberFormatter();

            // Test
            bool result = formatter.CanFormat(numberToFormat);

            //Verify
            Assert.AreEqual(false, result);
        }

        [Test]
        public void ShouldNotAbleToConvertNumberThatIsLessThanABillion() {
            // Setup
            const double numberToFormat = 999999999;
            INumberFormatter formatter = new BillionNumberFormatter();

            // Test
            bool result = formatter.CanFormat(numberToFormat);

            //Verify
            Assert.AreEqual(false, result);
        }
    }
}