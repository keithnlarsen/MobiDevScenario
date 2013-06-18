namespace Formatster.Core
{
    public class DefaultNumberFormatter : INumberFormatter
    {
        public string Handle(double numberToFormat)
        {
            return numberToFormat.ToString();
        }

        public bool CanHandle(double numberToFormat)
        {
            return (numberToFormat < 1000000);
        }
    }
}