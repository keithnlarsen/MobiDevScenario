namespace Formatster.Core
{
    public class BillionNumberFormatter : INumberFormatter
    {
        public string Format(double numberToFormat)
        {
            return (numberToFormat / 1000000000D).ToString("0.#") + "B";
        }

        public bool CanFormat(double numberToFormat)
        {
            throw new System.NotImplementedException();
        }
    }
}