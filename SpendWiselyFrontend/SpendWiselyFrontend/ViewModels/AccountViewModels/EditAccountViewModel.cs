using Microsoft.Extensions.DependencyInjection;
using SpendWiselyFrontend.ClientServices;
using SpendWiselyFrontend.ClientServices.Abstractions;
using SpendWiselyFrontend.Dtos;
using SpendWiselyFrontend.ViewModels.Abstractions;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace SpendWiselyFrontend.ViewModels.AccountViewModels
{
    public class EditAccountViewModel : BaseViewModel
    {
        private readonly IMoneyAccountService _moneyAccountService;
        private readonly IRestService _restService;
        public AccountDto Account { get; set; }
        public Command SaveCommand { get; }
        public Command DeleteCommand { get; }
        public EditAccountViewModel()
        {
            
        }
        public EditAccountViewModel(RestService restService)
        {
            _moneyAccountService = App.ServiceProvider.GetService<IMoneyAccountService>();
            _restService = restService;
            SaveCommand = new Command(async () => await SaveAccount());
            DeleteCommand = new Command(async () => await DeleteAccount());
        }
        public async void LoadAccount(int id)
        {
            var account = await _restService.GetAsync<AccountDto>($"api/accounts/{id}");
            Account = account;
            OnPropertyChanged(nameof(Account));
        }
        private async Task SaveAccount()
        {
            var result = await _restService.PutAsync($"api/accounts/{Account.Id}", Account);
            //var result = await _moneyAccountService.EditAccount(Account.Id, Account);
            if (result)
            {
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Błąd", "Nie udało się zapisać konta.", "OK");
            }
        }
        private async Task DeleteAccount()
        {
            var confirmed = await Application.Current.MainPage.DisplayAlert(
            "Deleting Account",
            "Are you sure you want to delete account",
            "Yep",
            "Nah");

            if (!confirmed) return;

            var success = await _restService.DeleteAsync($"api/accounts/{Account.Id}");
            if (success)
            {
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Błąd", "Nie udało się usunąć konta.", "OK");
            }
        }
    }
}
