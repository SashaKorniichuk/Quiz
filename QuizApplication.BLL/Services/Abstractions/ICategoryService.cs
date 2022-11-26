using QuizApplication.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.BLL.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAllCategories();
    }
}
