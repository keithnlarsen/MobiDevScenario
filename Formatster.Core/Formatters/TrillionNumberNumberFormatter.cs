namespace Formatster.Core.Formatters
{
    public class TrillionNumberNumberFormatter : NumberFormatterBase
    {
        public override string Handle(double numberToFormat)
        {
            return (numberToFormat / 1000000000000D).ToString("0.#") + "T";
        }

        public override bool CanHandle(double numberToFormat)
        {
            return (numberToFormat >= 1000000000000);
        }
    }
}