using DriveFlowXamarin.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DriveFlowXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartingPage : ContentPage
    {
        public StartingPage()
        {
            InitializeComponent();
            this.BindingContext = new StartingPageViewModel();
        }
        private async void GoToLoginPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
        private async void GoToRegisterPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}