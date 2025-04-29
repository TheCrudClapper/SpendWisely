using Microsoft.Extensions.DependencyInjection;
using Refit;
using SpendWiselyFrontend.ClientServices;
using SpendWiselyFrontend.ClientServices.Abstractions;
using SpendWiselyFrontend.ViewModels;
using SpendWiselyFrontend.ViewModels.Abstractions;
using System;
using System.Net.Http;
using Xamarin.Forms;

namespace SpendWiselyFrontend
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public const string ApiBaseUrl = "http://localhost:5187";
        public App()
        {
            InitializeComponent();

            var services = new ServiceCollection();

            //singletons
            services.AddSingleton<AppShell>();
            services.AddSingleton<IRestService, ClientServices.RestService>();

            //refit clients
            services.AddRefitClientFor<IMoneyAccountService>(ApiBaseUrl);

            //registering vm's
            services.AddTransient<MainPageViewModel>();

            //service provider
            ServiceProvider = services.BuildServiceProvider();

            //MainPage = new AppShell();
            MainPage = ServiceProvider.GetRequiredService<AppShell>();
        }
    }
}
