using Cirrious.MvvmCross.ViewModels;
using Formatster.Core.Formatters;

namespace Formatster.Core.ViewModels
{
    public class TestViewModel : MvxViewModel
    {
        private readonly INumberFormatter _numberFormatter;

        private string _formattedNumber;
        private double _myNumber;

        public TestViewModel(INumberFormatter numberFormatter)
        {
            _numberFormatter = numberFormatter;
        }

        public double MyNumber
        {
            get { return _myNumber; }
            set
            {
                _myNumber = value;
                RaisePropertyChanged(() => MyNumber);
                FormattedNumber = _numberFormatter.PrettyPrint(_myNumber);
            }
        }

        public string FormattedNumber
        {
            get { return _formattedNumber; }
            set
            {
                _formattedNumber = value;
                RaisePropertyChanged(() => FormattedNumber);
            }
        }
    }
}