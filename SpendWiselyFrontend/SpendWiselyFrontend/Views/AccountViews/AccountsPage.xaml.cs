using SpendWiselyFrontend.ClientServices;
using SpendWiselyFrontend.Dtos;
using SpendWiselyFrontend.ViewModels.AccountViewModels;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpendWiselyFrontend.Views.AccountViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AccountsPage : ContentPage
	{
		public AccountsPage ()
		{
			InitializeComponent ();
			this.BindingContext = new AccountsViewModel();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var viewModel = (AccountsViewModel)BindingContext;
            await viewModel.LoadItemsAsync(); // Load items when the page appears
        }
    }
}