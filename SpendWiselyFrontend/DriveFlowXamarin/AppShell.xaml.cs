﻿using DriveFlowXamarin.Views;
using SpendWiselyFrontend.Views;
using SpendWiselyFrontend.Views.BudgetViews;
using SpendWiselyFrontend.Views.AccountViews;
using SpendWiselyFrontend.Views.TransactionViews;
using SpendWiselyFrontend.Views.ExpenseViews;
using SpendWiselyFrontend.Views.RecuringExpenseViews;
using SpendWiselyFrontend.Views.IncomeViews;
using System;
using Xamarin.Forms;

namespace DriveFlowXamarin
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(AccountsPage), typeof(AccountsPage));
            Routing.RegisterRoute(nameof(AddAccountPage), typeof(AddAccountPage));
            Routing.RegisterRoute(nameof(BudgetsView), typeof(BudgetsView));
            Routing.RegisterRoute(nameof(TransactionsPage), typeof(TransactionsPage));
            Routing.RegisterRoute(nameof(AddIncomePage), typeof(AddIncomePage));
            Routing.RegisterRoute(nameof(AddExpensePage), typeof(AddExpensePage));
            Routing.RegisterRoute(nameof(AddBudgetPage), typeof(AddBudgetPage));
            //Routing.RegisterRoute(nameof(AddRecuringExpensePage), typeof(RecuringExpensePage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
