using System;

namespace Formatster.Core.Formatters
{
    public class MillionNumberFormatter : NumberFormatterBase
    {
        public override string Handle(double numberToFormat)
        {
            return (numberToFormat / 1000000D).ToString("0.#") + "M";
        }

        public override bool CanHandle(double numberToFormat)
        {
            return (Math.Abs(numberToFormat) >= 1000000 && Math.Abs(numberToFormat) < 1000000000);
        }
    }
}