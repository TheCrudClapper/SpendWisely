using Refit;
using SpendWiselyFrontend.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpendWiselyFrontend.Services.Abstractions
{
    interface ICategoryService
    {
        [Post("/api/Categories")]
        Task AddCategory(CategoryDto dto);

        [Get("/api/Categories")]
        Task<IEnumerable<CategoryDto>> GetCategories();

        [Get("/api/Categories/{id}")]
        Task<CategoryDto> GetCategory(int id);

        [Delete("/api/Categories/{id}")]
        Task Delete(int id);

        [Put("/api/Categories/{id}")]
        Task Edit(int id, [Body]CategoryDto dto);
    }
}
