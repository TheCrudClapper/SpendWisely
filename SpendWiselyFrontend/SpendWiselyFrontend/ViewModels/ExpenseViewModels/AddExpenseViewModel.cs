using SpendWiselyFrontend;
using SpendWiselyFrontend.ClientServices;
using SpendWiselyFrontend.Dtos;
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
    public class AddExpenseViewModel : BaseSingleViewModel
    {
        #region Fields
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
        #endregion
        public ObservableCollection<AccountDto> Accounts { get; set; }
        public ObservableCollection<CategoryDto> Categories { get; set; }

        private readonly IRestService _restService;

        public AddExpenseViewModel()
        {

        }
        public AddExpenseViewModel(IRestService restService)
        {
            _restService = restService;
            Accounts = new ObservableCollection<AccountDto>();
            Categories = new ObservableCollection<CategoryDto>();
        }
        public async Task LoadAccountList()
        {
            var accountsResponse = await _restService.GetAsync<List<AccountDto>>("api/accounts");
            Accounts.Clear();
            foreach(var account in accountsResponse)
            {
                Accounts.Add(account);
            }
        }
        public async Task LoadCategoriesList()
        {
            var categoriesResponse = await _restService.GetAsync<List<CategoryDto>>("api/categories");
            Categories.Clear();
            foreach (var category in categoriesResponse)
            {
                Categories.Add(category);
            }
        }
        //protected override async void Save()
        //{
        //    if (IsBusy)
        //        return;

        //    IsBusy = true;

        //    var account = new ExpenseDto
        //    {
        //        UserId = 1,
        //        Name = Name,
        //        Balance = CurrentBalance,
        //        Description = Description,
        //        EmojiUrl = Emoji
        //    };

        //    try
        //    {
        //        var createdAccount = await _restService.PostAsync<AccountDto, AccountDto>("api/accounts", account);
        //        await AppShell.Current.DisplayAlert("Success", "Account Added!", "OK");
        //        await Shell.Current.GoToAsync("..");
        //    }
        //    catch (System.Exception ex)
        //    {
        //        await AppShell.Current.DisplayAlert("Error", ex.Message, "OK");
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}

        //protected override void ClearInputs()
        //{
        //    Name = string.Empty;
        //    Emoji = string.Empty;
        //    Description = string.Empty;
        //    CurrentBalance = 0;
        //}
    }
}
