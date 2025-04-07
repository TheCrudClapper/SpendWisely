using SpendWiselyFrontend.Views.BudgetViews;
using SpendWiselyFrontend.Views.AccountViews;
using SpendWiselyFrontend.Views.TransactionViews;
using SpendWiselyFrontend.Views.CategoryViews;
using Xamarin.Forms;
using System.Threading.Tasks;


namespace SpendWiselyFrontend.ViewModels
{
    public class MainPageViewModel
    {
        public Command OpenAccountsPageCommand { get; set; }
        public Command OpenAccountsBudgetsCommand { get; set; }
        public Command OpenTransactionsCommand { get; set; }

        public Command OpenCategoriesPageCommand { get; set; }
        public MainPageViewModel()
        {
            OpenAccountsPageCommand = new Command(async () => await OpenAccountsPage());
            OpenAccountsBudgetsCommand = new Command(async () => await OpenBudgetsPage());
            OpenTransactionsCommand = new Command(async () => await OpenTransactionsPage());
            OpenCategoriesPageCommand = new Command(async () => await OpenCategoriesPage());
        }
        private async Task OpenAccountsPage()
        {
            await Shell.Current.GoToAsync($"/{nameof(AccountsPage)}");
        }
        private async Task OpenBudgetsPage()
        {
            await Shell.Current.GoToAsync($"/{nameof(BudgetsView)}");
        }
        private async Task OpenTransactionsPage()
        {
            await Shell.Current.GoToAsync($"/{nameof(TransactionsPage)}");
        }
        private async Task OpenCategoriesPage()
        {
            await Shell.Current.GoToAsync($"/{nameof(CategoriesPage)}");
        }
    }
}
