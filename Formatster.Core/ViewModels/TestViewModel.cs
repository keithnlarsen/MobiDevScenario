using Cirrious.MvvmCross.ViewModels;
using Formatster.Core.Formatters;

namespace Formatster.Core.ViewModels
{
    public class TestViewModel : MvxViewModel
    {
        private readonly INumberFormatter _numberFormatter;

        public TestViewModel(INumberFormatter numberFormatter)
        {
            _numberFormatter = numberFormatter;
        }

        private long _myNumber;

        public long MyNumber
        {
            get { return _myNumber; }
            set
            {
                _myNumber = value;
                RaisePropertyChanged(() => MyNumber);
                RaisePropertyChanged(() => FormattedNumber);
            }
        }

        public string FormattedNumber
        {
            get { return _numberFormatter.PrettyPrint(_myNumber); }
        }
    }
}