using Refit;
using SpendWiselyFrontend.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpendWiselyFrontend.Services.Abstractions
{
    public interface IIncomeService : ICrudApiService<IncomeDto>
    {
        [Get("/api/Incomes")]
        new Task<IEnumerable<Dtos.IncomeDto>> GetAll();

        [Get("/api/Incomes/{id}")]
        new Task<IncomeDto> GetById(int id);

        [Post("/api/Incomes")]
        new Task Add([Body]IncomeDto dto);

        [Put("/api/Incomes/{id}")]
        new Task Edit(int id, [Body]IncomeDto dto);

        [Delete("/api/Incomes/{id}")]
        new Task Delete(int id);
    }
}

