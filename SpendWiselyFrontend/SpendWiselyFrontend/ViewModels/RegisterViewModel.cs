using SpendWiselyFrontend.Views;
using SpendWiselyFrontend.ViewModels.Abstractions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SpendWiselyFrontend.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {

        private string email;
        private string username;
        private string password;
        private string confirmPassword;
        public Command GoToLoginPageCommand { get; set; }
        public Command GoToMainPageCommand { get; set; }

        public RegisterViewModel()
        {
            GoToLoginPageCommand = new Command(async () => await OpenLoginPage());
            GoToMainPageCommand = new Command(async () => await OpenMainPage());
        }

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public string ConfirmPassword
        {
            get => confirmPassword;
            set => SetProperty(ref confirmPassword, value);
        }

        private async Task OpenLoginPage()
        {
            await Shell.Current.GoToAsync($"/{nameof(LoginPage)}");
        }
        private async Task OpenMainPage()
        {
            await Shell.Current.GoToAsync($"/{nameof(MainPage)}");
        }
    }
}
