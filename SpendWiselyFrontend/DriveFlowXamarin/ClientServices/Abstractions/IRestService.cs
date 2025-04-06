using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpendWiselyFrontend.ViewModels.Abstractions
{
    public interface IRestService
    {
        Task<TResponse> GetAsync<TResponse>(string uri);
        Task<IEnumerable<TResponse>> GetListAsync<TResponse>(string uri);
        Task<TResponse> PostAsync<TRequest, TResponse>(string uri, TRequest requestBody);
        Task<bool> PostAsync<TRequest>(string uri, TRequest requestBody);
        Task<bool> PutAsync<TRequest>(string uri, TRequest requestBody);
        Task<bool> DeleteAsync(string uri);
    }
}
