using SpendWiselyFrontend.ViewModels.ExpenseViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpendWiselyFrontend.Views.ExpenseViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(ExpenseId), "expenseId")]
    public partial class EditExpensePage : ContentPage
	{
        public string ExpenseId
        {
            set
            {
                var vm = BindingContext as EditExpenseViewModel;
                vm?.LoadItem(int.Parse(value));
            }
        }
        public EditExpensePage ()
		{
			InitializeComponent ();
		}
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var vm = (EditExpenseViewModel)BindingContext;
            await vm?.LoadAccountList();
            await vm?.LoadCategoriesList();
        }
    }
}