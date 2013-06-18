namespace Formatster.Core
{
    public interface INumberFormatter
    {
        string FormatOhSoPretty(double numberToFormat);
        string Handle(double numberToFormat);
        bool CanHandle(double numberToFormat);
        void AddFormatterToChain(INumberFormatter numberFormatter);
    }
}