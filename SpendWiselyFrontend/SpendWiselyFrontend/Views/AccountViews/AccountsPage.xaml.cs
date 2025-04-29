using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpendWiselyFrontend.ClientServices;
using SpendWiselyFrontend.Dtos;
using SpendWiselyFrontend.ViewModels.AccountViewModels;
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
			this.BindingContext = new AccountsViewModel(new RestService());
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var viewModel = (AccountsViewModel)BindingContext;
            await viewModel.LoadItemsAsync(); // Load items when the page appears
        }
        public void OnAccountSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is AccountDto selectedAccount)
            {
                var vm = BindingContext as AccountsViewModel;
                vm?.OpenEditAccountPageCommand.Execute(selectedAccount);
            }

             //for unchecking
             ((CollectionView)sender).SelectedItem = null;
        }
    }
}