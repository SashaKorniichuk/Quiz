using QuizApplication.BLL.Services.Abstractions;
using QuizApplication.BLL.ViewModels;
using QuizApplication.DAL.Entity;
using QuizApplication.DAL.Repositories.Abstarctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.BLL.Services
{
    public class QuestionService:IQuestionService
    {
        private readonly IGenericRepository<Question> _questionRepository;
        private readonly IGenericRepository<Answer> _answerRepository; 
        public QuestionService(IGenericRepository<Question> questionRepository,IGenericRepository<Answer> answerRepository)
        {
            _questionRepository= questionRepository;
            _answerRepository= answerRepository;
        }

        public async Task<List<QuestionAnswerViewModel>> GetAllQuestionsByCategoryId(int categoryId)
        {
            Random rnd = new Random();            
            var questions = await _questionRepository.GetAsync(x => x.CategoryId==categoryId);
            questions=questions.OrderBy(x => rnd.Next()).Take(5);
            List<QuestionAnswerViewModel> questionAnswerViewModels = new List<QuestionAnswerViewModel>();
            foreach (var q in questions)
            {
                var answers = await _answerRepository.GetAsync(x => x.QuestionId==q.Id);
                List<QuestionOption> answersOptions = new List<QuestionOption>();
                foreach(var answer in answers)
                {
                    QuestionOption option = new QuestionOption()
                    {
                        OptionId= answer.Id,
                        OptionName=answer.Text,
                        IsCorrect=answer.IsCorrect,
                    };
                    answersOptions.Add(option);                  
                }

                QuestionAnswerViewModel questionAnswerViewModel = new QuestionAnswerViewModel()
                {
                    QuestionId= q.Id,
                    QuestionName=q.Text,
                    ListOfOption=answersOptions
                };
                questionAnswerViewModels.Add(questionAnswerViewModel);
            }

            return questionAnswerViewModels;
        }
    }
}
