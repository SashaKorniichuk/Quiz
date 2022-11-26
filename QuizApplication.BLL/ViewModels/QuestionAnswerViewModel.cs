using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.BLL.ViewModels
{
    public class QuestionAnswerViewModel
    {
        public int OptionId { get; set; }
        public int QuestionId { get; set; } 
        public string QuestionName { get; set; }
        public List<QuestionOption> ListOfOption { get; set; } 
    }

    public class QuestionOption
    {
        public int OptionId { get; set; }
        public string OptionName { get; set; }
        public bool IsCorrect { get; set; }
    }
}
