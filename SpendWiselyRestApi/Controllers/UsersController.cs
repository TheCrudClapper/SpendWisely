using Entities.DatabaseContexts;
using Entities.Models.IdentityEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Services.Dtos;
using Services.ServiceContracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly DatabaseContext _context;
    private readonly IConfiguration _config;
    private readonly IAuthService _authService;
    private readonly UserManager<ApplicationUser> _userManager;

    public UsersController(IAuthService authService ,DatabaseContext context, UserManager<ApplicationUser> userManger, IConfiguration config)
    {
        _authService = authService;
        _context = context;
        _userManager = userManger;
        _config = config;
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {;
        var result = await _authService.RegisterAsync(dto);
        if (!result.Success)
            return BadRequest(result.Errors);
        else
            return Ok(new { message = "User registered successfully" });
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var result = await _authService.LoginAsync(dto);
        if (!result.Success)
            return Unauthorized(result.Errors.FirstOrDefault());

        return Ok(new { result.Token });
    }
}