﻿using Microsoft.Extensions.DependencyInjection;
using SpendWiselyFrontend.ClientServices.Abstractions;
using SpendWiselyFrontend.Services.Abstractions;
using SpendWiselyFrontend.ViewModels;
using SpendWiselyFrontend.ViewModels.Abstractions;
using System;
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
            services.AddRefitClientFor<IAuthService>(ApiBaseUrl, useAuth: false);
            services.AddRefitClientFor<IMoneyAccountService>(ApiBaseUrl, useAuth: true);
            services.AddRefitClientFor<ICategoryService>(ApiBaseUrl, useAuth: true);
            services.AddRefitClientFor<IExpenseService>(ApiBaseUrl, useAuth: true);
            services.AddRefitClientFor<IIncomeService>(ApiBaseUrl, useAuth: true);

            //registering vm's
            services.AddTransient<MainPageViewModel>();

            //service provider
            ServiceProvider = services.BuildServiceProvider();

            //MainPage = new AppShell();
            MainPage = ServiceProvider.GetRequiredService<AppShell>();
        }
    }
}
