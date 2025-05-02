using SpendWiselyFrontend.Views;
using SpendWiselyFrontend.ViewModels.Abstractions;
using System.Threading.Tasks;
using Xamarin.Forms;
using SpendWiselyFrontend.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using SpendWiselyFrontend.Dtos;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpendWiselyFrontend.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {

        private readonly IAuthService _authService;
        private string email;
        private string username;
        private string password;
        private string confirmPassword;
        public Command GoToLoginPageCommand { get; set; }
        public Command GoToMainPageCommand { get; set; }

        public Command RegisterCommand { get; set; }

        public RegisterViewModel()
        {
            _authService = App.ServiceProvider.GetService<IAuthService>();
            GoToLoginPageCommand = new Command(async () => await OpenLoginPage());
            GoToMainPageCommand = new Command(async () => await OpenMainPage());
            RegisterCommand = new Command(async () => await Register());
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

        private async Task Register()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please fill in all fields", "OK");
                return;
            }

            if (Password != ConfirmPassword)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Passwords do not match", "OK");
                return;
            }

            try
            {
                await _authService.Register(new RegisterDto()
                {
                    Email = email,
                    Password = password,
                    UserName = username
                });
                await Application.Current.MainPage.DisplayAlert("Success", "Registration successful. Please login.", "OK");
                await Shell.Current.GoToAsync($"/{nameof(LoginPage)}");
            }
            catch (ApiException apiEx)
            {
                await Application.Current.MainPage.DisplayAlert("Error", apiEx.Content ?? "Registration failed", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
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
