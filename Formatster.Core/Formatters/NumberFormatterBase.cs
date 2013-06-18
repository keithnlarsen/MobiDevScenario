namespace Formatster.Core.Formatters
{
    public abstract class NumberFormatterBase : INumberFormatter
    {
        private NumberFormatterBase _nextFormatter;

        public string PrettyPrint(double numberToFormat)
        {
            if (CanHandle(numberToFormat))
                return Handle(numberToFormat);

            return _nextFormatter.PrettyPrint(numberToFormat);
        }

        public abstract string Handle(double numberToFormat);

        public abstract bool CanHandle(double numberToFormat);

        public NumberFormatterBase AddFormatterToChain(NumberFormatterBase numberFormatter)
        {
            if (_nextFormatter == null)
                _nextFormatter = numberFormatter;
            else
                _nextFormatter.AddFormatterToChain(numberFormatter);

            return this;
        }
    }
}