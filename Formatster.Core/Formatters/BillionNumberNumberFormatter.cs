namespace Formatster.Core.Formatters
{
    public class BillionNumberNumberFormatter : NumberFormatterBase
    {
        public override string Handle(double numberToFormat)
        {
            return (numberToFormat / 1000000000D).ToString("0.#") + "B";
        }

        public override bool CanHandle(double numberToFormat)
        {
            return (numberToFormat >= 1000000000 && numberToFormat < 1000000000000);
        }
    }
}