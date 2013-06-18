namespace Formatster.Core.Formatters
{
    public class MillionNumberNumberFormatter : NumberFormatterBase
    {
        public override string Handle(double numberToFormat)
        {
            return (numberToFormat / 1000000D).ToString("0.#") + "M";
        }

        public override bool CanHandle(double numberToFormat)
        {
            return (numberToFormat >= 1000000 && numberToFormat < 1000000000);
        }
    }
}