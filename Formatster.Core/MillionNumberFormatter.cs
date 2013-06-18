namespace Formatster.Core
{
    public class MillionNumberFormatter : INumberFormatter
    {
        public string Handle(double numberToFormat)
        {
            return (numberToFormat / 1000000D).ToString("0.#") + "M";
        }

        public bool CanHandle(double numberToFormat)
        {
            return (numberToFormat >= 1000000 && numberToFormat < 1000000000);
        }
    }
}