using Microsoft.Extensions.DependencyInjection;
using SpendWiselyFrontend.ClientServices;
using SpendWiselyFrontend.ClientServices.Abstractions;
using SpendWiselyFrontend.Dtos;
using SpendWiselyFrontend.ViewModels.Abstractions;
using SpendWiselyFrontend.Views.AccountViews;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SpendWiselyFrontend.ViewModels.AccountViewModels
{
    public class AccountsViewModel : BaseManyViewModel<AccountDto>
    {

        private readonly IRestService _restService;
        private readonly IMoneyAccountService _moneyAccountService;
        public AccountsViewModel()
        {
            _restService = App.ServiceProvider.GetService<IRestService>();
        }
        public Command<AccountDto> OpenEditAccountPageCommand { get; set; }
        public Command OpenAddAccountPageCommand { get; set; }
        public AccountsViewModel(RestService restService)
        {
            _moneyAccountService = App.ServiceProvider.GetService<IMoneyAccountService>();
            _restService = App.ServiceProvider.GetService<IRestService>();
            OpenEditAccountPageCommand = new Command<AccountDto>(async (account) => await OpenEditAccountPage(account));
            OpenAddAccountPageCommand = new Command(OpenAddAccountPage);
        }
        public async void OpenAddAccountPage()
        {
            await Shell.Current.GoToAsync($"/{nameof(AddAccountPage)}");
        }
        private async Task OpenEditAccountPage(AccountDto account)
        {
            if (account == null) return;
            await Shell.Current.GoToAsync($"{nameof(EditAccountPage)}?accountId={account.Id}");
        }
        public async override Task LoadItemsAsync()
        {
            IsBusy = true;
            try
            {
                var accountsResponse = await _moneyAccountService.GetAccounts();
                Items.Clear();
                foreach (var account in accountsResponse)
                {
                    Items.Add(account);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Failed to fetch acoounts");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
