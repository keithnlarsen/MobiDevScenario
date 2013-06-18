namespace Formatster.Core
{
    public class TrillionNumberFormatter : INumberFormatter
    {
        public string Handle(double numberToFormat)
        {
            return (numberToFormat / 1000000000000D).ToString("0.#") + "T";
        }

        public bool CanHandle(double numberToFormat)
        {
            return (numberToFormat >= 1000000000000);
        }
    }
}