using SpendWiselyFrontend.ClientServices;
using SpendWiselyFrontend.ViewModels.BudgetViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpendWiselyFrontend.Views.BudgetViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddBudgetPage : ContentPage
	{
		public AddBudgetPage ()
		{
			InitializeComponent ();
            this.BindingContext = new AddBudgetViewModel(new RestService());
        }
	}
}