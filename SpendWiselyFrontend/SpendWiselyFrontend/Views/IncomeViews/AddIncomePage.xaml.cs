using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SpendWiselyFrontend.ViewModels.IncomeViewModels;

namespace SpendWiselyFrontend.Views.IncomeViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddIncomePage : ContentPage
	{
		public AddIncomePage ()
		{
			InitializeComponent ();
			this.BindingContext = new AddIncomeViewModel();
		}
	}
}