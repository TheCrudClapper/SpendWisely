using System.Net.Http;
using Xamarin.Forms;

namespace DriveFlowXamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
