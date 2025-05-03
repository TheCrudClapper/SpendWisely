using Microsoft.Extensions.DependencyInjection;
using SpendWiselyFrontend.ClientServices.Abstractions;
using SpendWiselyFrontend.Dtos;
using SpendWiselyFrontend.ViewModels.Abstractions;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace SpendWiselyFrontend.ViewModels.AccountViewModels
{
    public class AddAccountViewModel : BaseSingleViewModel<AccountDto, IMoneyAccountService>
    {
        private readonly IMoneyAccountService _moneyAccountService;
        public AddAccountViewModel()
        {
            _moneyAccountService = App.ServiceProvider.GetService<IMoneyAccountService>();
        }
        #region Fields
        private string name;
        private string emoji;
        private string description;
        private decimal currentBalance;
        #endregion
        #region MVVMProperties
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
        #endregion
        protected override async Task Save()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            var account = new AccountDto
            {
                Name = Name,
                Balance = CurrentBalance,
                Description = Description,
                EmojiUrl = Emoji
            };

            try
            {
                await _moneyAccountService.Add(account);
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
