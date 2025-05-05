using SpendWiselyFrontend.ViewModels.CategoriesViewModels;
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
	public partial class ExpensesPage : ContentPage
	{
		public ExpensesPage ()
		{
			InitializeComponent ();
            this.BindingContext = new ExpensesViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var viewModel = (ExpensesViewModel)BindingContext;
            await viewModel.LoadItemsAsync();
        }
    }
}