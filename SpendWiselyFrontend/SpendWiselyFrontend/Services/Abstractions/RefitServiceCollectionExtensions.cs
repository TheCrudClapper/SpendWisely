using Microsoft.Extensions.DependencyInjection;
using Refit;
using SpendWiselyFrontend.Helpers;
using System;
using Xamarin.Essentials;

namespace SpendWiselyFrontend.ClientServices.Abstractions
{
    public static class RefitServiceCollectionExtensions
    {
        public static IServiceCollection AddRefitClientFor<TClient>(this IServiceCollection services, string baseUrl, bool useAuth = true)
            where TClient : class
        {
            var refitBuilder = services.AddRefitClient<TClient>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));

            if (useAuth)
            {
                services.AddTransient<AuthHeaderHandler>();
                refitBuilder.AddHttpMessageHandler<AuthHeaderHandler>();
            }

            return services;
        }
    }
}

