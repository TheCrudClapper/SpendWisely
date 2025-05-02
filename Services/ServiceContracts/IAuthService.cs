using Entities.Models.IdentityEntities;
using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServiceContracts
{
    public interface IAuthService
    {
        Task<AuthResponseDto> LoginAsync(LoginDto request);
        string GenenerateJwtToken(ApplicationUser user);
        Task<AuthResponseDto> RegisterAsync(RegisterDto request);
    }
}
