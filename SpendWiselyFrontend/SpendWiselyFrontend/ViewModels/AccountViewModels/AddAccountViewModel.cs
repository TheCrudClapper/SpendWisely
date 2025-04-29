using Microsoft.Extensions.DependencyInjection;
using SpendWiselyFrontend.ClientServices.Abstractions;
using SpendWiselyFrontend.Dtos;
using SpendWiselyFrontend.ViewModels.Abstractions;
using Xamarin.Forms;


namespace SpendWiselyFrontend.ViewModels.AccountViewModels
{
    public class AddAccountViewModel : BaseSingleViewModel
    {
        private readonly IMoneyAccountService _moneyAccountService;

        public AddAccountViewModel()
        {
            _moneyAccountService = App.ServiceProvider.GetService<IMoneyAccountService>();
        }
        private string name;
        private string emoji;
        private string description;
        private decimal currentBalance;

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Emoji
        {
            get => emoji;
            set => SetProperty(ref emoji, value);
        }

        public decimal CurrentBalance
        {
            get => currentBalance;
            set => SetProperty(ref currentBalance, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        protected override async void SaveChanges()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            var account = new AccountDto
            {
                UserId = 1, 
                Name = Name,
                Balance = CurrentBalance,
                Description = Description,
                EmojiUrl = Emoji
            };

            try
            {
                await _moneyAccountService.AddAccount(account);
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
            CurrentBalance = 0;
        }
    }
}
