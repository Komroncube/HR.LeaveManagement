using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Models.Identity;
using HR.LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Identity.Services;
public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly JwtSettings jwtSettings;

    public AuthService(UserManager<ApplicationUser> userManager,
                       SignInManager<ApplicationUser> signInManager,
                       IOptions<JwtSettings> jwtSettings)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.jwtSettings = jwtSettings.Value;
    }

    public async Task<AuthResponse> Login(AuthRequest authRequest)
    {
        ApplicationUser user = await userManager.FindByEmailAsync(authRequest.Email);
        if (user is null)
        {
            throw new NotFoundException(nameof(ApplicationUser), authRequest.Email);
        }

        SignInResult result = await signInManager.PasswordSignInAsync(user, authRequest.Password, false, false);
        
        if (!result.Succeeded)
        {
            throw new ApplicationException($"Credentials for '{authRequest.Email}' aren't valid");
        }

        JwtSecurityToken jwtSecurityToken = await GenerateJwtToken(user);

        AuthResponse authResponse = new()
        {
            Id = user.Id,
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            Email = user.Email,
            UserName = user.UserName
        };

        return authResponse;
    }

    public Task<RegistrationResponse> Register(RegistrationRequest registrationRequest)
    {
        throw new NotImplementedException();
    }

    private async Task<JwtSecurityToken> GenerateJwtToken(ApplicationUser user)
    {
        IEnumerable<Claim> userClaims = await userManager.GetClaimsAsync(user);
        IEnumerable<string> roles = await userManager.GetRolesAsync(user);

        IEnumerable<Claim> roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role));

        IEnumerable<Claim> claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("uid", user.Id)
        }
        .Union(userClaims)
        .Union(roleClaims);

        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(jwtSettings.Secret));
        SigningCredentials signingCredentials = new(key, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: jwtSettings.Issuer,
            audience: jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(jwtSettings.ExpiryInMinutes),
            signingCredentials: signingCredentials
            );
        return jwtSecurityToken;
    }
}
