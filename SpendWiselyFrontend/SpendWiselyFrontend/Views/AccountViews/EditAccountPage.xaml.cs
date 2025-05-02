using SpendWiselyFrontend.ClientServices;
using SpendWiselyFrontend.ViewModels.AccountViewModels;
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
                vm?.LoadItem(int.Parse(value));
            }
        }
        public EditAccountPage ()
		{
			InitializeComponent ();
		}
	}
}