using Formatster.Core;
using NUnit.Framework;

namespace Formatster.Tests.Unit
{
    [TestFixture]
    public class TrillionNumberFormatterTests
    {
        [Test]
        public void ShouldConvertTrillionWithDecimalThatHasToRoundUp()
        {
            // Setup
            const long numberToFormat = 12350000000000;
            const string expectedResult = "12.4T";
            INumberFormatter formatter = new TrillionNumberFormatter();

            // Test
            string result = formatter.Format(numberToFormat);

            //Verify
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ShouldConvertTrillionWithNoDecimal()
        {
            // Setup
            const long numberToFormat = 1000000000000;
            const string expectedResult = "1T";
            INumberFormatter formatter = new TrillionNumberFormatter();

            // Test
            string result = formatter.Format(numberToFormat);

            //Verify
            Assert.AreEqual(expectedResult, result);
        }
    }
}