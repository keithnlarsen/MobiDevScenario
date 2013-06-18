using Formatster.Core;
using NUnit.Framework;

namespace Formatster.Tests.Unit
{
    [TestFixture]
    public class DefaultNumberFormatterTests
    {
        [Test]
        public void ShouldBeAbleToConvertANumberThatIsLessThanAMillion()
        {
            // Setup
            const double numberToFormat = 123349;
            INumberFormatter formatter = new DefaultNumberFormatter();

            // Test
            bool result = formatter.CanFormat(numberToFormat);

            //Verify
            Assert.AreEqual(true, result);
        }

        [Test]
        public void ShouldNotAbleToConvertNumberThatIsGreaterThanOrEqualToAMillion()
        {
            // Setup
            const double numberToFormat = 1233000000;
            INumberFormatter formatter = new DefaultNumberFormatter();

            // Test
            bool result = formatter.CanFormat(numberToFormat);

            //Verify
            Assert.AreEqual(false, result);
        }

        [Test]
        public void ShouldNotPrettyUpANumberThatHasADecimal()
        {
            // Setup
            const double numberToFormat = 1233.23;
            const string expectedResult = "1233.23";
            INumberFormatter formatter = new DefaultNumberFormatter();

            // Test
            string result = formatter.Format(numberToFormat);

            //Verify
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ShouldNotPrettyUpANumberThatHasNoDecimal()
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
    }
}