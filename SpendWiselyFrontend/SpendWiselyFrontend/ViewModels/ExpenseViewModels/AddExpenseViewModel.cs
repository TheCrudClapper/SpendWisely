using Microsoft.Extensions.DependencyInjection;
using SpendWiselyFrontend;
using SpendWiselyFrontend.ClientServices;
using SpendWiselyFrontend.ClientServices.Abstractions;
using SpendWiselyFrontend.Dtos;
using SpendWiselyFrontend.Services.Abstractions;
using SpendWiselyFrontend.ViewModels.Abstractions;
using SpendWiselyFrontend.ViewModels.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SpendWiselyFrontend.ViewModels.ExpenseViewModels
{
    public class AddExpenseViewModel : BaseSingleViewModel<ExpenseDto, IExpenseService>
    {
        #region Fields
        private readonly IExpenseService _expenseService;
        private readonly IMoneyAccountService _moneyAccountService;
        private readonly ICategoryService _categoryService;
        private int selectedCategoryId;
        private int selectedAccountId;
        private decimal amount;
        private string description;
        private string name;
        private string emoji;

        #endregion
        #region Props
        public int SelectedCategoryId
        {
            get => selectedCategoryId;
            set => SetProperty(ref selectedCategoryId, value);
        }
        public int SelectedAccountId
        {
            get => selectedAccountId;
            set => SetProperty(ref selectedAccountId, value);
        }
        public decimal Amount
        {
            get => amount;
            set => SetProperty(ref amount, value);
        }
        public string Emoji
        {
            get => emoji;
            set => SetProperty(ref emoji, value);
        }
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        public ObservableCollection<AccountDto> Accounts { get; set; }
        public ObservableCollection<CategoryDto> Categories { get; set; }
        #endregion
        public AddExpenseViewModel()
        {
            _expenseService = App.ServiceProvider.GetService<IExpenseService>();
            _moneyAccountService = App.ServiceProvider.GetService<IMoneyAccountService>();
            _categoryService = App.ServiceProvider.GetService<ICategoryService>();
            Accounts = new ObservableCollection<AccountDto>();
            Categories = new ObservableCollection<CategoryDto>();
        }
        public async Task LoadAccountList()
        {
            var accounts = await _moneyAccountService.GetAll();
            Accounts.Clear();
            foreach(var account in accounts)
            {
                Accounts.Add(account);
            }
        }
        public async Task LoadCategoriesList()
        {
            var categories = await _categoryService.GetAll();
            Categories.Clear();
            foreach (var category in categories)
            {
                Categories.Add(category);
            }
        }
        protected override async Task Save()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            var expense = new ExpenseDto
            {
                Name = name,
                Description = description,
                AccountId = selectedAccountId,
                CategoryId = selectedCategoryId,
                Amount = amount,
            };


            try
            {
                await _expenseService.Add(expense);
                await AppShell.Current.DisplayAlert("Success", "Account Added!", "OK");
                await Shell.Current.GoToAsync("..");
            }
            catch (System.Exception ex)
            {
                await AppShell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        protected override void ClearInputs()
        {
            Name = string.Empty;
            Emoji = string.Empty;
            Description = string.Empty;
            Amount = default;
            SelectedAccountId = default;
            SelectedCategoryId = default;
        }
    }
}
