using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SpendWiselyFrontend.ClientServices;
using SpendWiselyFrontend.ViewModels.AccountViewModels;
using SpendWiselyFrontend.ViewModels.TransactionViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpendWiselyFrontend.Views.TransactionViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TransactionsPage : ContentPage
	{
		public TransactionsPage ()
		{
			InitializeComponent ();
			this.BindingContext = new TransactionsViewModel(new RestService());
		}
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var viewModel = (TransactionsViewModel)BindingContext;
            await viewModel.LoadExpensesAsync();
            await viewModel.LoadIncomesAsync();
            await viewModel.LoadRecuringExpensesAsync();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!ExpandableMenu.IsVisible)
            {
                ExpandableMenu.IsVisible = true;
                await ExpandableMenu.TranslateTo(0, 0, 250, Easing.CubicOut);
            }
            else
            {
                await ExpandableMenu.TranslateTo(0, -ExpandableMenu.Height, 250, Easing.CubicIn);
                ExpandableMenu.IsVisible = false;
            }
        }
    }
}