using Refit;
using SpendWiselyFrontend.Dtos;
using System.Threading.Tasks;

namespace SpendWiselyFrontend.Services.Abstractions
{
    public interface IAuthService
    {
        [Post("/api/Users/Register")]
        Task Register([Body] RegisterDto dto);

        [Post("/api/Users/Login")]
        Task<LoginResponseDto> Login([Body] LoginDto dto);
    }
}
