using Cirrious.CrossCore;
using Formatster.Core.Formatters;

namespace Formatster.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            // Register my Chain of Reponsiblity
            Mvx.RegisterSingleton<INumberFormatter>(
                new TrillionNumberNumberFormatter()
                    .AddFormatterToChain(new BillionNumberNumberFormatter())
                    .AddFormatterToChain(new MillionNumberNumberFormatter())
                    .AddFormatterToChain(new DefaultNumberFormatter()));

            RegisterAppStart<ViewModels.TestViewModel>();
        }
    }
}