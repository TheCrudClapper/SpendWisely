using SpendWiselyFrontend.ClientServices;
using SpendWiselyFrontend.ViewModels.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpendWiselyFrontend.Views.AccountViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddAccountPage : ContentPage
	{
		public AddAccountPage ()
		{
			InitializeComponent ();
			this.BindingContext = new AddAccountViewModel();
        }
	}
}