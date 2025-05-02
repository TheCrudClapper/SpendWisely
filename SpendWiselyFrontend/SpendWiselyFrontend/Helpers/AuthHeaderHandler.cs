using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Xamarin.Essentials;

namespace SpendWiselyFrontend.Helpers
{
    public class AuthHeaderHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await SecureStorage.GetAsync("jwt_token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
