using SpendWiselyFrontend.ClientServices;
using SpendWiselyFrontend.Dtos;
using SpendWiselyFrontend.ViewModels.Abstractions;
using SpendWiselyFrontend.Views.AccountViews;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SpendWiselyFrontend.ViewModels.AccountViewModels
{
    public class AccountsViewModel : BaseManyViewModel<AccountDto>
    {

        private readonly IRestService _restService;
        public AccountsViewModel()
        {
            
        }
        public Command<AccountDto> OpenEditAccountPageCommand { get; set; }
        public Command OpenAddAccountPageCommand { get; set; }
        public AccountsViewModel(RestService restService)
        {
            OpenEditAccountPageCommand = new Command<AccountDto>(async (account) => await OpenEditAccountPage(account));
            OpenAddAccountPageCommand = new Command(OpenAddAccountPage);
            _restService = restService;
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
                var accountsResponse = await _restService.GetAsync<List<AccountDto>>("api/accounts");
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
