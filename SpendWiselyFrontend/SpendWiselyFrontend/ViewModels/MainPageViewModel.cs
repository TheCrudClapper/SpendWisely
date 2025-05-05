using SpendWiselyFrontend.Views.BudgetViews;
using SpendWiselyFrontend.Views.AccountViews;
using SpendWiselyFrontend.Views.TransactionViews;
using SpendWiselyFrontend.Views.CategoryViews;
using Xamarin.Forms;
using System.Threading.Tasks;
using SpendWiselyFrontend.Views.IncomeViews;
using SpendWiselyFrontend.Views.ExpenseViews;


namespace SpendWiselyFrontend.ViewModels
{
    public class MainPageViewModel
    {
        public Command OpenAccountsPageCommand { get; set; }
        public Command OpenAccountsBudgetsCommand { get; set; }
        public Command OpenTransactionsCommand { get; set; }

        public Command OpenExpensesCommand { get; set; }
        public Command OpenIncomesCommand { get; set; }
        public Command OpenRecuringExpensesCommand { get; set; }


        public Command OpenCategoriesPageCommand { get; set; }
        public MainPageViewModel()
        {
            OpenAccountsPageCommand = new Command(async () => await OpenAccountsPage());
            OpenAccountsBudgetsCommand = new Command(async () => await OpenBudgetsPage());
            OpenTransactionsCommand = new Command(async () => await OpenTransactionsPage());
            OpenCategoriesPageCommand = new Command(async () => await OpenCategoriesPage());
            OpenRecuringExpensesCommand = new Command(OpenExpensesPage);
            OpenIncomesCommand = new Command(OpenIncomesPage);
            OpenExpensesCommand = new Command(OpenRecuringExpensesPage);
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
        private void OpenExpensesPage()
        {
            Shell.Current.GoToAsync($"/{nameof(ExpensesPage)}");
        }
        private void OpenRecuringExpensesPage()
        {
            Shell.Current.GoToAsync($"/{nameof(ExpensesPage)}");
        }
        private void OpenIncomesPage()
        {
            Shell.Current.GoToAsync($"/{nameof(IncomesPage)}");
        }
    }
}
