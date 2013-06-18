namespace Formatster.Core
{
    public class BillionNumberFormatter : INumberFormatter
    {
        public string Format(long numberToFormat)
        {
            return (numberToFormat / 1000000000D).ToString("0.#") + "B";
        }
    }
}