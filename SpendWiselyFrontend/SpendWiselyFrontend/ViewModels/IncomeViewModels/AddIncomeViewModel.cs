using Microsoft.Extensions.DependencyInjection;
using SpendWiselyFrontend.ClientServices.Abstractions;
using SpendWiselyFrontend.Dtos;
using SpendWiselyFrontend.Services.Abstractions;
using SpendWiselyFrontend.ViewModels.Abstractions;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SpendWiselyFrontend.ViewModels.IncomeViewModels
{
    public class AddIncomeViewModel : BaseSingleViewModel<IncomeDto, IIncomeService>
    {
        #region Fields
        private readonly IIncomeService _incomeService;
        private readonly IMoneyAccountService _moneyAccountService;
        private AccountDto selectedAccount;
        private int selectedAccountId;
        private decimal amount;
        private string description;
        private string name;
        private string emoji;
        #endregion
        #region Props
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
        #endregion
        public AddIncomeViewModel()
        {
            _incomeService = App.ServiceProvider.GetService<IIncomeService>();
            _moneyAccountService = App.ServiceProvider.GetService<IMoneyAccountService>();
            Accounts = new ObservableCollection<AccountDto>();
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
        protected override async Task Save()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            var income = new IncomeDto
            {
                Name = name,
                Description = description,
                AccountId = selectedAccountId,
                EmojiUrl = emoji,
                Amount = amount,
            };


            try
            {
                await _incomeService.Add(income);
                await AppShell.Current.DisplayAlert("Success", "Income Added!", "OK");
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
        }
    }
}