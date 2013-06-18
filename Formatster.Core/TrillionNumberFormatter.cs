namespace Formatster.Core
{
    public class TrillionNumberFormatter : INumberFormatter
    {
        public string Format(double numberToFormat)
        {
            return (numberToFormat / 1000000000000D).ToString("0.#") + "T";
        }

        public bool CanFormat(double numberToFormat)
        {
            return (numberToFormat >= 1000000000000);
        }
    }
}