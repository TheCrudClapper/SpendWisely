using Microsoft.Extensions.DependencyInjection;
using SpendWiselyFrontend.ClientServices.Abstractions;
using SpendWiselyFrontend.Dtos;
using SpendWiselyFrontend.Services.Abstractions;
using SpendWiselyFrontend.ViewModels.Abstractions;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SpendWiselyFrontend.ViewModels.IncomeViewModels
{
    public class EditIncomeViewModel : BaseSingleViewModel<IncomeDto, IIncomeService>
    {
        private readonly IMoneyAccountService _moneyAccountService;
        private AccountDto selectedAccount;
        private int selectedAccountId;
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
        public ObservableCollection<AccountDto> Accounts { get; set; }
        public EditIncomeViewModel()
        {
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
        protected override async Task Update()
        {
            Item.AccountId = SelectedAccountId;
            await base.Update();
        }
    }
}
