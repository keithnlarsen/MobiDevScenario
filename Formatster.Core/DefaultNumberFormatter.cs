namespace Formatster.Core
{
    public class DefaultNumberFormatter : INumberFormatter
    {
        public string Format(double numberToFormat)
        {
            return numberToFormat.ToString();
        }

        public bool CanFormat(double numberToFormat)
        {
            return (numberToFormat < 1000000);
        }
    }
}