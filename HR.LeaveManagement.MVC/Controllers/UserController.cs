using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IAuthService authService;

        public UserController(IAuthService authService)
        {
            this.authService = authService;
        }

        public IActionResult Login(string returnUrl = null)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                returnUrl ??= Url.Content("~/");
                var result = await authService.Authenticate(model.Email, model.Password);
                if (result)
                {
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                var returnUrl = Url.Content("~/");
                var isSuccess = await authService.Register(registerVM);
                if (isSuccess)
                {
                    LocalRedirect(returnUrl);
                }
            }
            ModelState.AddModelError(string.Empty, "Invalid registration attempt.");
            return View(registerVM);
        }

        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl)
        {
            returnUrl ??= Url.Content("~/");
            await authService.Logout();
            return LocalRedirect(returnUrl);
        }
    }
}
