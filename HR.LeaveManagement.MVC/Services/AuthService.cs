using AutoMapper;
using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models.Auth;
using HR.LeaveManagement.MVC.Services.Base;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HR.LeaveManagement.MVC.Services;

public class AuthService : BaseHttpService, IAuthService
{
    private readonly IMapper mapper;
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly JwtSecurityTokenHandler jwtSecurityTokenHandler;
    public AuthService(
        IClient client,
        ICacheStorageService cacheStorageService,
        IHttpContextAccessor httpContextAccessor,
        IMapper mapper)
        : base(cacheStorageService, client)
    {
        this.httpContextAccessor = httpContextAccessor;
        jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        this.mapper = mapper;
    }
    public async Task<bool> Authenticate(string email, string password)
    {
        try
        {
            AuthRequest authRequest = new() { Email = email, Password = password };
            AuthResponse authResponse = await _client.LoginAsync(authRequest);

            if (string.IsNullOrEmpty(authResponse.Token))
            {
                return false;
            }
            // Get Claims from token and build auth user object
            JwtSecurityToken tokenContent = jwtSecurityTokenHandler.ReadJwtToken(authResponse.Token);
            var claims = ParseClaims(tokenContent);
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
            var login = httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user);
            _cacheStorageService.SetStorageValue("token", authResponse.Token);
            return true;
        }
        catch
        {
            return false;
        }
    }

    private IEnumerable<Claim> ParseClaims(JwtSecurityToken tokenContent)
    {
        var claims = tokenContent.Claims.ToList();
        claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
        return claims;
    }

    public async Task<bool> Register(RegisterVM register)
    {
        var registerRequest = mapper.Map<RegistrationRequest>(register);
        var response = await _client.RegisterAsync(registerRequest);
        if (string.IsNullOrEmpty(response.UserId))
        {
            return false;
        }
        return await Authenticate(register.Email, register.Password);
    }

    public async Task Logout()
    {
        _cacheStorageService.ClearStorage(new List<string> { "token" });
        await httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }
}
