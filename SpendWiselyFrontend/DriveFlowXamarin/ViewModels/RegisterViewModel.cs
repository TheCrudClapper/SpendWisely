using DriveFlowXamarin.Views;
using SpendWiselyFrontend.ViewModels.Abstractions;
using Xamarin.Forms;

namespace DriveFlowXamarin.ViewModels
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
            GoToLoginPageCommand = new Command(OpenLoginPage);
            GoToMainPageCommand = new Command(OpenMainPage);
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

        private async void OpenLoginPage()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
        private async void OpenMainPage()
        {
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
    }
}
