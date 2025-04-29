using SpendWiselyFrontend.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpendWiselyFrontend.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            this.BindingContext = new RegisterViewModel();
        }
    }
}