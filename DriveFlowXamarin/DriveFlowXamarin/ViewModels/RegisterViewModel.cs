using DriveFlowXamarin.Views;
using Xamarin.Forms;

namespace DriveFlowXamarin.ViewModels
{
    public class RegisterViewModel
    {
        public Command GoToLoginPageCommand { get; set; }
        public Command GoToMainPageCommand { get; set; }
        public RegisterViewModel()
        {
            GoToLoginPageCommand = new Command(OpenLoginPage);
            GoToMainPageCommand = new Command(OpenMainPage);
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
