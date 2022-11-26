using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApplication.BLL.Services;
using QuizApplication.BLL.Services.Abstractions;
using QuizApplication.BLL.ViewModels;
using QuizApplication.Models;
using System.Diagnostics;

namespace QuizApplication.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _categoryService;
      
        public HomeController(ILogger<HomeController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService=categoryService;
        }

        public async Task<IActionResult> Index()
        {
            List<CategoryViewModel> categories = await _categoryService.GetAllCategories();       
            return View(categories);
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}