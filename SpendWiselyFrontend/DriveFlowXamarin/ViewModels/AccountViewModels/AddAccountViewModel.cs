using DriveFlowXamarin;
using SpendWiselyFrontend.Dtos;
using SpendWiselyFrontend.ViewModels.Abstractions;
using SpendWiselyFrontend.Views.ExpenseViews;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace SpendWiselyFrontend.ViewModels.AccountViewModels
{
    public class AddAccountViewModel : BaseSingleViewModel
    {
        private readonly IRestService _restService;

        public AddAccountViewModel(IRestService restService)
        {
            _restService = restService;
        }
        public AddAccountViewModel()
        {
            
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
                var createdAccount = await _restService.PostAsync<AccountDto, AccountDto>("api/accounts", account);
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
