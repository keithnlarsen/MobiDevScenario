namespace Formatster.Core
{
    public class MillionNumberFormatter : INumberFormatter
    {
        public string Format(double numberToFormat)
        {
            return (numberToFormat / 1000000D).ToString("0.#") + "M";
        }

        public bool CanFormat(double numberToFormat)
        {
            throw new System.NotImplementedException();
        }
    }
}