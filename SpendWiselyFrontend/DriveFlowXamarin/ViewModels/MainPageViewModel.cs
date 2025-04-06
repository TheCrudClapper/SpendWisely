using DriveFlowXamarin.Views;
using SpendWiselyFrontend.Views;
using SpendWiselyFrontend.Views.BudgetViews;
using SpendWiselyFrontend.Views.AccountViews;
using SpendWiselyFrontend.Views.TransactionViews;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SpendWiselyFrontend.ViewModels
{
    public class MainPageViewModel
    {
        public Command OpenAccountsPageCommand { get; set; }
        public Command OpenAccountsBudgetsCommand { get; set; }
        public Command OpenTransactionsCommand { get; set; }
        public MainPageViewModel()
        {
            OpenAccountsPageCommand = new Command(OpenAccountsPage);
            OpenAccountsBudgetsCommand = new Command(OpenBudgetsPage);
            OpenTransactionsCommand = new Command(OpenTransactionsPage);
        }
        private async void OpenAccountsPage()
        {
            await Shell.Current.GoToAsync($"/{nameof(AccountsPage)}");
        }
        private async void OpenBudgetsPage()
        {
            await Shell.Current.GoToAsync($"/{nameof(BudgetsView)}");
        }
        private async void OpenTransactionsPage()
        {
            await Shell.Current.GoToAsync($"/{nameof(TransactionsPage)}");
        }
    }
}
