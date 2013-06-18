namespace Formatster.Core
{
    public class DefaultNumberFormatter : FormatterBase
    {
        public override string Handle(double numberToFormat)
        {
            return numberToFormat.ToString();
        }

        public override bool CanHandle(double numberToFormat)
        {
            return (numberToFormat < 1000000);
        }
    }
}