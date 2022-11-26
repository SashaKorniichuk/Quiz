using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizApplication.BLL.Services;
using QuizApplication.BLL.Services.Abstractions;
using QuizApplication.BLL.ViewModels;
using QuizApplication.DAL.Entity;

namespace QuizApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService= accountService;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.Login(model);

                if (result.Succeeded)
                {
                    
                    //FormsAuthentication.SetAuthCookie(user.Username, false);
                    return RedirectToAction("Index", "Home");                   
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect password or login");
                }
            }
            return View(model);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {          
            await _accountService.Logout();          
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var res = await _accountService.Register(model);
                if (res.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in res.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
    }
}
