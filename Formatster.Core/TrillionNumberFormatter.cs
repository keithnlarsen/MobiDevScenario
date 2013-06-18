namespace Formatster.Core
{
    public class TrillionNumberFormatter : INumberFormatter
    {
        public string Format(long numberToFormat)
        {
            return (numberToFormat / 1000000000000D).ToString("0.#") + "T";
        }
    }
}