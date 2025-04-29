using SpendWiselyFrontend.ViewModels.Abstractions;
using SpendWiselyFrontend.Views.BudgetViews;
using SpendWiselyFrontend.Views.ExpenseViews;
using SpendWiselyFrontend.Views.RecuringExpenseViews;
using SpendWiselyFrontend.Views.IncomeViews;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using SpendWiselyFrontend.ClientServices;
using SpendWiselyFrontend.Dtos;
using System.Collections.ObjectModel;

namespace SpendWiselyFrontend.ViewModels.TransactionViewModel
{
    public class TransactionsViewModel : BaseViewModel
    {
        private readonly IRestService _restService;
        private ExpenseDto selectedExpense;
        private IncomeDto selectedIncome;
        private RecuringExpenseDto selectedRecuringExpense;
        public ObservableCollection<ExpenseDto> Expenses { get; set; }
        public ObservableCollection<IncomeDto> Incomes { get; set; }
        public ObservableCollection<RecuringExpenseDto> RecuringExpenses { get; set; }

        public ExpenseDto SelectedExpenseItem
        {
            get => selectedExpense;
            set
            {
                SetProperty(ref selectedExpense, value);
            }
        }
        public IncomeDto SelectedIncomeItem
        {
            get => selectedIncome;
            set
            {
                SetProperty(ref selectedIncome, value);
            }
        }
        public RecuringExpenseDto SelectedRecuringExpenseItem
        {
            get => selectedRecuringExpense;
            set
            {
                SetProperty(ref selectedRecuringExpense, value);
            }
        }

        public Command OpenAddExpenseCommand { get; set; }
        public Command OpenAddRecuringExpenseCommand { get; set; }
        public Command OpenAddIncomeCommand { get; set; }

        public TransactionsViewModel()
        {

        }
        public TransactionsViewModel(RestService restService)
        {
            _restService = restService;

            OpenAddExpenseCommand = new Command(OpenAddExpense);
            OpenAddRecuringExpenseCommand = new Command(OpenAddRecuringExpense);
            OpenAddIncomeCommand = new Command(OpenAddIncome);
            Expenses = new ObservableCollection<ExpenseDto>();
            Incomes = new ObservableCollection<IncomeDto>();
            RecuringExpenses = new ObservableCollection<RecuringExpenseDto>();
        }
        public async Task LoadExpensesAsync()
        {
            try
            {
                var expensesResponse = await _restService.GetAsync<List<ExpenseDto>>("api/Expenses");
                Expenses.Clear();
                foreach (var expense in expensesResponse)
                {
                    Expenses.Add(expense);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to fetch expenses");
            }
        }

        public async Task LoadIncomesAsync()
        {

            try
            {
                var incomeResponse = await _restService.GetAsync<List<IncomeDto>>("api/Incomes");
                Incomes.Clear();
                foreach (var income in incomeResponse)
                {
                    Incomes.Add(income);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to fetch incomes");
            }

        }
        public async Task LoadRecuringExpensesAsync()
        {

            //try
            //{
            //    var recuringExpenses = await _restService.GetAsync<List<RecuringExpenseDto>>("api/recuringexpenses");
            //    RecuringExpenses.Clear();
            //    foreach (var item in recuringExpenses)
            //    {
            //        RecuringExpenses.Add(item);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Failed to fetch recuring expenses");
            //}
        }

        private async void OpenAddExpense()
        {
            await Shell.Current.GoToAsync($"/{nameof(AddExpensePage)}");
        }
        private async void OpenAddRecuringExpense()
        {
            //await Shell.Current.GoToAsync($"/{nameof(AddRecuringExpensePage)}");
        }
        private async void OpenAddIncome()
        {
            await Shell.Current.GoToAsync($"/{nameof(AddIncomePage)}");
        }
    }
}
