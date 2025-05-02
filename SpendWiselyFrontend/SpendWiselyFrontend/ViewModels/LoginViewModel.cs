using SpendWiselyFrontend.Views;
using SpendWiselyFrontend.ViewModels.Abstractions;
using Xamarin.Forms;
using System.Threading.Tasks;
using SpendWiselyFrontend.Dtos;
using SpendWiselyFrontend.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Essentials;
using Refit;
using System;

namespace SpendWiselyFrontend.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Fields
        private readonly IAuthService _authService;
        private string email;
        private string password;
        #endregion
        #region MVVM Fields
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }
        #endregion
        
        public Command LoginCommand { get; }
        public Command GoToRegisterPageCommand { get; }

        public LoginViewModel()
        {
            _authService = App.ServiceProvider.GetService<IAuthService>();
            LoginCommand = new Command(async ()  => await Login());
            GoToRegisterPageCommand = new Command(OpenRegisterPage);
        }

        private async Task Login()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please fill in both email and password", "OK");
                return;
            }

            try
            {
                var loginResult = await _authService.Login(new LoginDto()
                {
                    Email = email,
                    Password = password,
                });
                await SecureStorage.SetAsync("jwt_token", loginResult.Token);
                OpenMainPage();
            }
            catch (ApiException apiEx)
            {
                await Application.Current.MainPage.DisplayAlert("Error", apiEx.Content ?? "Invalid credentials", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");

            }
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
