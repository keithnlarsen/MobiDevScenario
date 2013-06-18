namespace Formatster.Core
{
    public interface INumberFormatter
    {
        string Format(double numberToFormat);
        bool CanFormat(double numberToFormat);
    }
}