using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SpendWiselyFrontend.ViewModels.BudgetViewModels;
using SpendWiselyFrontend.ClientServices;

namespace SpendWiselyFrontend.Views.BudgetViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BudgetsView : ContentPage
	{
		public BudgetsView ()
		{
			InitializeComponent ();
			this.BindingContext = new BudgetsViewModel(new RestService());
		}
	}
}