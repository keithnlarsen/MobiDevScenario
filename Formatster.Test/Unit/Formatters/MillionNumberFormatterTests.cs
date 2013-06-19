using Formatster.Core.Formatters;
using NUnit.Framework;

namespace Formatster.Tests.Unit.Formatters
{
    [TestFixture]
    public class MillionNumberFormatterTests
    {
        [Test]
        public void ShouldBeAbleToConvertANumberThatisLessThanOrEqualToNegativeAMillion() {
            // Setup
            const double numberToFormat = -1000000;
            INumberFormatter formatter = new MillionNumberFormatter();

            // Test
            bool result = formatter.CanHandle(numberToFormat);

            //Verify
            Assert.AreEqual(true, result);
        }

        [Test]
        public void ShouldBeAbleToConvertANumberThatGreaterThanOrEqualToAMillion()
        {
            // Setup
            const double numberToFormat = 1000000;
            INumberFormatter formatter = new MillionNumberFormatter();

            // Test
            bool result = formatter.CanHandle(numberToFormat);

            //Verify
            Assert.AreEqual(true, result);
        }

        [Test]
        public void ShouldConvertNegativeAMillionToDecimalThatHasToRoundUp() {
            // Setup
            const double numberToFormat = -12350000;
            const string expectedResult = "-12.4M";
            INumberFormatter formatter = new MillionNumberFormatter();

            // Test
            string result = formatter.Handle(numberToFormat);

            //Verify
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ShouldConvertMillionToDecimalThatHasToRoundUp()
        {
            // Setup
            const double numberToFormat = 12350000;
            const string expectedResult = "12.4M";
            INumberFormatter formatter = new MillionNumberFormatter();

            // Test
            string result = formatter.Handle(numberToFormat);

            //Verify
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ShouldConvertMillionToNoDecimalNumber()
        {
            // Setup
            const double numberToFormat = 1000000;
            const string expectedResult = "1M";
            INumberFormatter formatter = new MillionNumberFormatter();

            // Test
            string result = formatter.Handle(numberToFormat);

            //Verify
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ShouldConvertMillionWithDecimalsToDecimalThatDoesNotRoundUp()
        {
            // Setup
            const double numberToFormat = 12330000.23;
            const string expectedResult = "12.3M";
            INumberFormatter formatter = new MillionNumberFormatter();

            // Test
            string result = formatter.Handle(numberToFormat);

            //Verify
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ShouldNotAbleToConvertNumberThatIsGreaterThanOrEqualToABillion()
        {
            // Setup
            const double numberToFormat = 1000000000;
            INumberFormatter formatter = new MillionNumberFormatter();

            // Test
            bool result = formatter.CanHandle(numberToFormat);

            //Verify
            Assert.AreEqual(false, result);
        }

        [Test]
        public void ShouldNotAbleToConvertNumberThatIsLessThanAMillion()
        {
            // Setup
            const double numberToFormat = 999999;
            INumberFormatter formatter = new MillionNumberFormatter();

            // Test
            bool result = formatter.CanHandle(numberToFormat);

            //Verify
            Assert.AreEqual(false, result);
        }
    }
}