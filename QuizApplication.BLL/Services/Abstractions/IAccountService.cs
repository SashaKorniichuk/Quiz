using Microsoft.AspNetCore.Identity;
using QuizApplication.BLL.ViewModels;

namespace QuizApplication.BLL.Services.Abstractions
{
    public interface IAccountService
    {
        Task<IdentityResult> Register(RegisterViewModel registerViewModel);
        Task<SignInResult> Login(LoginViewModel loginViewModel);
        Task Logout();
    }
}
