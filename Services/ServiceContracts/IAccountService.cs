using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServiceContracts
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountDto>> GetAllAsync();
        Task<AccountDto> GetAccountAsync(int id);
        Task AddAccoutnAsync(AccountDto request);
        Task DeleteAsync(int id);
        Task EditAccountAsync(int id, AccountDto dto);
    }
}
