using System;

namespace Formatster.Core.Formatters
{
    public class TrillionNumberFormatter : NumberFormatterBase
    {
        public override string Handle(double numberToFormat)
        {
            return (numberToFormat / 1000000000000D).ToString("0.#") + "T";
        }

        public override bool CanHandle(double numberToFormat)
        {
            return (Math.Abs(numberToFormat) >= 1000000000000);
        }
    }
}