using HR.LeaveManagement.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Contracts.Identity;
public interface IAuthService
{
    Task<RegistrationResponse> Register(RegistrationRequest registrationRequest);
    Task<AuthResponse> Login(AuthRequest authRequest);
}
