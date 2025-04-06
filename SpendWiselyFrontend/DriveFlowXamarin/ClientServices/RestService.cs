﻿using SpendWiselyFrontend.ViewModels.Abstractions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SpendWiselyFrontend.ClientServices
{
    public class RestService : IRestService
    {
        private readonly HttpClient httpClient;
        public RestService()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5187/")
            };
        }

        public Task<bool> DeleteAsync(string uri)
        {
            throw new NotImplementedException();
        }

        public async Task<TResponse> GetAsync<TResponse>(string uri)
        {
            var response = await httpClient.GetAsync(uri);
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public Task<IEnumerable<TResponse>> GetListAsync<TResponse>(string uri)
        {
            throw new NotImplementedException();
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string uri, TRequest requestBody)
        {
            var content = SerializeContent(requestBody);
            var response = await httpClient.PostAsync(uri, content);

            response.EnsureSuccessStatusCode(); // to rzuca wyjątek jeśli nie 2xx

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<bool> PostAsync<TRequest>(string uri, TRequest requestBody)
        {
            var content = SerializeContent(requestBody);
            var response = await httpClient.PostAsync(uri, content);
            return response.IsSuccessStatusCode;
        }

        public Task<bool> PutAsync<TRequest>(string uri, TRequest requestBody)
        {
            throw new NotImplementedException();
        }
        private StringContent SerializeContent<TRequest>(TRequest requestBody)
        {
            var json = JsonSerializer.Serialize(requestBody);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
