using SpendWiselyFrontend.ViewModels.IncomeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpendWiselyFrontend.Views.IncomeViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IncomesPage : ContentPage
	{
		public IncomesPage ()
		{
			InitializeComponent ();
            this.BindingContext = new IncomesViewModel();
        }
	}
}