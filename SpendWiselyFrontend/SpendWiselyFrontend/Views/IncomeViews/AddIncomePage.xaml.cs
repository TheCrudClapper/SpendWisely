using SpendWiselyFrontend.ViewModels.IncomeViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var vm = (AddIncomeViewModel)BindingContext;
            await vm?.LoadAccountList();
        }
    }
}