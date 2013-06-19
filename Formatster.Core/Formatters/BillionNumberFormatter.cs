using System;

namespace Formatster.Core.Formatters
{
    public class BillionNumberFormatter : NumberFormatterBase
    {
        public override string Handle(double numberToFormat)
        {
            return (numberToFormat / 1000000000D).ToString("0.#") + "B";
        }

        public override bool CanHandle(double numberToFormat)
        {
            return (Math.Abs(numberToFormat) >= 1000000000 && Math.Abs(numberToFormat) < 1000000000000);
        }
    }
}