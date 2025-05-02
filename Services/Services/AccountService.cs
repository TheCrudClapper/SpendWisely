using Entities.Dtos;
using Services.ServiceContracts;

namespace Services.Services
{
    public class AccountService : IAccountService
    {
        public Task AddAccoutnAsync(AccountDto request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditAccountAsync(int id, AccountDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<AccountDto> GetAccountAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AccountDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
