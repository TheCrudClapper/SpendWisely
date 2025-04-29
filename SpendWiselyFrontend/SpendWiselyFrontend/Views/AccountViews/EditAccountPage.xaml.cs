using SpendWiselyFrontend.ClientServices;
using SpendWiselyFrontend.Dtos;
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
    [QueryProperty(nameof(AccountId), "accountId")]
    public partial class EditAccountPage : ContentPage
	{
        public string AccountId
        {
            set
            {
                var vm = BindingContext as EditAccountViewModel;
                vm?.LoadAccount(int.Parse(value));
            }
        }
        public EditAccountPage ()
		{
			InitializeComponent ();
			this.BindingContext = new EditAccountViewModel(new RestService());
		}
	}
}