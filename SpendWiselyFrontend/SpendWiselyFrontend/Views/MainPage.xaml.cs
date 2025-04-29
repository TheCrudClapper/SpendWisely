using SpendWiselyFrontend.ViewModels;
using SpendWiselyFrontend.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpendWiselyFrontend.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel();
        }
    }
}