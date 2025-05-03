using SpendWiselyFrontend.ClientServices;
using SpendWiselyFrontend.ViewModels.AccountViewModels;
using SpendWiselyFrontend.ViewModels.ExpenseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpendWiselyFrontend.Views.ExpenseViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddExpensePage : ContentPage
	{
		public AddExpensePage ()
		{
			InitializeComponent ();
			this.BindingContext = new AddExpenseViewModel();
		}
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var viewModel = (AddExpenseViewModel)BindingContext;
            await viewModel.LoadAccountList();
            await viewModel.LoadCategoriesList();
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}