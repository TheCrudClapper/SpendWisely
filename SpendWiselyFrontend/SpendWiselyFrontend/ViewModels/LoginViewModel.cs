using SpendWiselyFrontend.Views;
using SpendWiselyFrontend.ViewModels.Abstractions;
using Xamarin.Forms;

namespace SpendWiselyFrontend.ViewModels
{
    public class LoginViewModel : BaseViewModel
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
            await Shell.Current.GoToAsync($"/MainPage");
        }
        private async void OpenRegisterPage()
        {
            await Shell.Current.GoToAsync($"/{nameof(RegisterPage)}");
        }
    }
}
