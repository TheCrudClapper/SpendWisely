using DriveFlowXamarin.ViewModels;
using SpendWiselyFrontend.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DriveFlowXamarin.Views
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