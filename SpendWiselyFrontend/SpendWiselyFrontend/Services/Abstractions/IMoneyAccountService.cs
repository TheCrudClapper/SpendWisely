using Refit;
using SpendWiselyFrontend.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpendWiselyFrontend.ClientServices.Abstractions
{
    public interface IMoneyAccountService
    {
        [Get("/api/Accounts")]
        Task<List<AccountDto>> GetAccounts();

        [Get("/api/Accounts/{id}")]
        Task<AccountDto> GetAccount(int id);

        [Post("/api/Accounts")]
        Task AddAccount(AccountDto dto);

        [Put("/api/accounts/{id}")]
        Task<bool> EditAccount(int id, [Body] AccountDto dto);

        [Delete("/api/Accounts/{id}")]
        Task DeleteAccound(int id);
    }
}
