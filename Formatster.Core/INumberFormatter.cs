namespace Formatster.Core
{
    public interface INumberFormatter
    {
        string Handle(double numberToFormat);
        bool CanHandle(double numberToFormat);
    }
}