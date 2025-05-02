using Refit;
using SpendWiselyFrontend.Dtos.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpendWiselyFrontend.Services.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="Model">can be a model or dto</typeparam>
    public interface ICrudApiService<Dto>
    {
        [Get("/")]
        Task<IEnumerable<Dto>> GetAll();
        [Get("/")]
        Task<Dto> GetById(int id);
        [Post("/")]
        Task Add(Dto dto);
        [Put("/")]
        Task Edit(int id, Dto dto);
        [Delete("/")]
        Task Delete(int id);
    }
}
