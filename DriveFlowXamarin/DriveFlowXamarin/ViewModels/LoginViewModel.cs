using DriveFlowXamarin.Views;
using Xamarin.Forms;

namespace DriveFlowXamarin.ViewModels
{
    public class LoginViewModel
    {
        public Command LoginCommand { get; }
        public Command GoToRegisterPageCommand { get; }
        public LoginViewModel()
        {
            LoginCommand = new Command(OpenMainPage);
            GoToRegisterPageCommand = new Command(OpenRegisterPage);
        }
        private async void OpenMainPage()
        {
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
        private async void OpenRegisterPage()
        {
            await Shell.Current.GoToAsync($"/{nameof(RegisterPage)}");
        }
    }
}
