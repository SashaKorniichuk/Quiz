using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApplication.BLL.Services.Abstractions;
using QuizApplication.BLL.ViewModels;

namespace QuizApplication.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private static List<QuestionAnswerViewModel> questions = new List<QuestionAnswerViewModel>();
        private readonly IQuestionService _questionService;
        private static int score = 0;
        private static int index = 0;
        private static int maxIndex = 5;
        public GameController(IQuestionService questionService)
        {
            _questionService= questionService;
        }
        public IActionResult Index()
        {
            return View(new QuestionAnswerViewModel());
        }

        [HttpGet("Start/{id}")]
        public IActionResult Start([FromRoute] int id)
        {
           
            return View("TestDescription", id);
        }

        [HttpGet("Proceed/{id}")]
        public async Task<IActionResult> Proceed([FromRoute] int id)
        {
            questions=await _questionService.GetAllQuestionsByCategoryId(id);
            index=0;
            score=0;
            return View("QuestionCard", questions[index]);
        }

        [HttpPost]
        public  IActionResult Next(bool Answer)
        {
            if (Answer)
            {
                score++;
            }

            index++;

            if (index==maxIndex)
            {
                return RedirectToAction("Result", "Game");
            }

            return View("QuestionCard", questions[index]);
        }

        public IActionResult Result()
        {
            ViewBag.Score=$"{score}/{maxIndex}";
            return View("Score");
        }
    }
}
