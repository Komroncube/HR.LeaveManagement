using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAuthService authService;

    public AccountController(IAuthService authService )
    {
        this.authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AuthRequest request)
    {
        AuthResponse response = await authService.Login(request);
        return Ok(response);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegistrationRequest request)
    {
        RegistrationResponse response = await authService.Register(request);
        return Ok(response);
    }
}
