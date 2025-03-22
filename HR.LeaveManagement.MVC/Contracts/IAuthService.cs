using HR.LeaveManagement.MVC.Models.Auth;

namespace HR.LeaveManagement.MVC.Contracts;

public interface IAuthService
{
    Task<bool> Authenticate(string email, string password);
    Task<bool> Register(RegisterVM registerVM);
    Task Logout();
}
