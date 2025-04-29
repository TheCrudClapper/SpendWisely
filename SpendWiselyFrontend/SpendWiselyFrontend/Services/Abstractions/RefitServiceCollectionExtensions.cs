using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpendWiselyFrontend.ClientServices.Abstractions
{
    public static class RefitServiceCollectionExtensions
    {
        public static IServiceCollection AddRefitClientFor<TClient>(this IServiceCollection services, string baseUrl)
            where TClient : class
        {
            services.AddRefitClient<TClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));
            return services;
        } 
    }
}
