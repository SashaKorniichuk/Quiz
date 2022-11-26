using Microsoft.AspNetCore.Identity;
using QuizApplication.BLL.Services.Abstractions;
using QuizApplication.DAL.Entity;
using QuizApplication.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<SignInResult> Login(LoginViewModel loginViewModel)
        {
            var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password,false,false);
            return result;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Register(RegisterViewModel registerViewModel)
        {

            User user = new User { Email = registerViewModel.Email, UserName = registerViewModel.Email };
            var result = await _userManager.CreateAsync(user, registerViewModel.Password);
           
            if (result.Succeeded)
            {
                // установка куки
                await _signInManager.SignInAsync(user, false);
            }

            return result;

        }
    }
}
