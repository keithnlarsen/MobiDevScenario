using Formatster.Core;
using NUnit.Framework;

namespace Formatster.Tests.Unit
{
    [TestFixture]
    public class TrillionNumberFormatterTests
    {
        [Test]
        public void SomeFailingTest()
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