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
                new TrillionNumberFormatter()
                    .AddFormatterToChain(new BillionNumberFormatter())
                    .AddFormatterToChain(new MillionNumberFormatter())
                    .AddFormatterToChain(new DefaultNumberFormatter()));

            RegisterAppStart<ViewModels.TestViewModel>();
        }
    }
}