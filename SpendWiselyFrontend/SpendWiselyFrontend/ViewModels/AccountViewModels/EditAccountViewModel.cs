using Microsoft.Extensions.DependencyInjection;
using SpendWiselyFrontend.ClientServices;
using SpendWiselyFrontend.ClientServices.Abstractions;
using SpendWiselyFrontend.Dtos;
using SpendWiselyFrontend.ViewModels.Abstractions;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace SpendWiselyFrontend.ViewModels.AccountViewModels
{
    public class EditAccountViewModel : BaseSingleViewModel
    {
        private readonly IMoneyAccountService _moneyAccountService;
        private readonly IRestService _restService;
        public AccountDto Account { get; set; }
        public EditAccountViewModel(RestService restService)
        {
            _moneyAccountService = App.ServiceProvider.GetService<IMoneyAccountService>();
            _restService = restService;
        }
        public EditAccountViewModel()
        {
            
        }
        public async void LoadAccount(int id)
        {
            Account = await _moneyAccountService.GetAccount(id);
            OnPropertyChanged(nameof(Account));
        }
        protected override async Task Save()
        {
            var result = await _moneyAccountService.EditAccount(Account.Id, Account);
            if (result)
            {
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Błąd", "Nie udało się zapisać konta.", "OK");
            }
        }
        protected override async Task Delete()
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
