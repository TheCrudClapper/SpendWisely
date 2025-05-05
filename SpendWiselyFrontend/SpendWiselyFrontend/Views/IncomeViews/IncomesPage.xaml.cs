using SpendWiselyFrontend.ViewModels.IncomeViewModels;
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
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var viewModel = (IncomesViewModel)BindingContext;
            await viewModel.LoadItemsAsync();
        }
    }
}