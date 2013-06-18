using Cirrious.CrossCore;
using Formatster.Core.Formatters;

namespace Formatster.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            var numberFormatter = new TrillionNumberNumberFormatter();
            numberFormatter.AddFormatterToChain(new BillionNumberNumberFormatter());
            numberFormatter.AddFormatterToChain(new MillionNumberNumberFormatter());
            numberFormatter.AddFormatterToChain(new DefaultNumberFormatter());
            
            Mvx.RegisterSingleton<INumberFormatter>(numberFormatter);
            RegisterAppStart<ViewModels.TestViewModel>();
        }
    }
}