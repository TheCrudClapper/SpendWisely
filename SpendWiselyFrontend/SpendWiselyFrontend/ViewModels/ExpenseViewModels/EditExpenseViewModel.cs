using Microsoft.Extensions.DependencyInjection;
using SpendWiselyFrontend.ClientServices.Abstractions;
using SpendWiselyFrontend.Dtos;
using SpendWiselyFrontend.Services.Abstractions;
using SpendWiselyFrontend.ViewModels.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SpendWiselyFrontend.ViewModels.ExpenseViewModels
{
    public class EditExpenseViewModel : BaseSingleViewModel<ExpenseDto, IExpenseService>
    {
        private readonly IMoneyAccountService _moneyAccountService;
        private readonly ICategoryService _categoryService;
        private int selectedCategoryId;
        private int selectedAccountId;
        private CategoryDto selectedCategory;
        private AccountDto selectedAccount;
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
        public CategoryDto SelectedCategory
        {
            get => selectedCategory;
            set
            {
                if (SetProperty(ref selectedCategory, value) && value != null)
                {
                    SelectedCategoryId = value.Id;
                }
            }
        }
        public AccountDto SelectedAccount
        {
            get => selectedAccount;
            set
            {
                if (SetProperty(ref selectedAccount, value) && value != null)
                {
                    SelectedAccountId = value.Id;
                }
            }
        }
        public ObservableCollection<AccountDto> Accounts { get; set; }
        public ObservableCollection<CategoryDto> Categories { get; set; }
        public EditExpenseViewModel()
        {
            _moneyAccountService = App.ServiceProvider.GetService<IMoneyAccountService>();
            _categoryService = App.ServiceProvider.GetService<ICategoryService>();
            Accounts = new ObservableCollection<AccountDto>();
            Categories = new ObservableCollection<CategoryDto>();
        }
        public async Task LoadAccountList()
        {
            var accounts = await _moneyAccountService.GetAll();
            Accounts.Clear();
            foreach (var account in accounts)
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
        protected override async Task Update()
        {
            if (Item != null)
            {
                Item.CategoryId = SelectedCategoryId;
                Item.AccountId = SelectedAccountId;
            }

            await base.Update(); 
        }
    }
}
