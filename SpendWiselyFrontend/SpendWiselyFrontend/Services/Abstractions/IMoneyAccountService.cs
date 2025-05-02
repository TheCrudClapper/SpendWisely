using Refit;
using SpendWiselyFrontend.Dtos;
using SpendWiselyFrontend.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpendWiselyFrontend.ClientServices.Abstractions
{
    public interface IMoneyAccountService : ICrudApiService<AccountDto>
    {
        [Get("/api/Accounts")]
        new Task<IEnumerable<AccountDto>> GetAll();

        [Get("/api/Accounts/{id}")]
        new Task<AccountDto> GetById(int id);

        [Post("/api/Accounts")]
        new Task Add([Body]AccountDto dto);

        [Put("/api/accounts/{id}")]
        new Task Edit(int id, [Body]AccountDto dto);

        [Delete("/api/Accounts/{id}")]
        new Task Delete(int id);
    }
}
