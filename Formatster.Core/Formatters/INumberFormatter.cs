namespace Formatster.Core.Formatters
{
    public interface INumberFormatter
    {
        string Handle(double numberToFormat);
        bool CanHandle(double numberToFormat);
        string PrettyPrint(double numberToFormat);
    }
}