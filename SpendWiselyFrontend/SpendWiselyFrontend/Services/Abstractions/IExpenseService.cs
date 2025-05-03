using Refit;
using SpendWiselyFrontend.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpendWiselyFrontend.Services.Abstractions
{
    public interface IExpenseService : ICrudApiService<ExpenseDto>
    {
        [Get("/api/Expenses")]
        new Task<IEnumerable<ExpenseDto>> GetAll();

        [Get("/api/Expenses/{id}")]
        new Task<ExpenseDto> GetById(int id);

        [Post("/api/Expenses")]
        new Task Add([Body] ExpenseDto dto);

        [Put("/api/Expenses/{id}")]
        new Task Edit(int id, [Body] ExpenseDto dto);

        [Delete("/api/Expenses/{id}")]
        new Task Delete(int id);
    }
}
