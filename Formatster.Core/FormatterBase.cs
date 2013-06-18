namespace Formatster.Core
{
    public abstract class FormatterBase : INumberFormatter
    {
        private INumberFormatter _nextFormatter;

        public string FormatOhSoPretty(double numberToFormat)
        {
            if (CanHandle(numberToFormat))
                return Handle(numberToFormat);

            return _nextFormatter.Handle(numberToFormat);
        }

        public abstract string Handle(double numberToFormat);

        public abstract bool CanHandle(double numberToFormat);

        public void AddFormatterToChain(INumberFormatter numberFormatter)
        {
            if (_nextFormatter == null)
                _nextFormatter = numberFormatter;

            _nextFormatter.AddFormatterToChain(numberFormatter);
        }
    }
}