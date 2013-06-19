using System;

namespace Formatster.Core.Formatters
{
    public class DefaultNumberFormatter : NumberFormatterBase
    {
        public override string Handle(double numberToFormat)
        {
            return numberToFormat.ToString();
        }

        public override bool CanHandle(double numberToFormat)
        {
            return (Math.Abs(numberToFormat) < 1000000);
        }
    }
}