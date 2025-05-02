using Refit;
using SpendWiselyFrontend.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpendWiselyFrontend.Services.Abstractions
{
    public interface ICategoryService : ICrudApiService<CategoryDto>
    {
        //by new override methods from parent service 
        [Get("/api/Categories")]
        new Task<IEnumerable<CategoryDto>> GetAll();

        [Get("/api/Categories/{id}")]
        new Task<CategoryDto> GetById(int id);

        [Post("/api/Categories")]
        new Task Add([Body] CategoryDto dto);

        [Put("/api/Categories/{id}")]
        new Task Edit(int id, [Body] CategoryDto dto);

        [Delete("/api/Categories/{id}")]
        new Task Delete(int id);
    }
}
