namespace Formatster.Core
{
    public class DefaultNumberFormatter : INumberFormatter
    {
        public string Format(double numberToFormat)
        {
            return numberToFormat.ToString();
        }
    }
}