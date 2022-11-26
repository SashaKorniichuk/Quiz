using QuizApplication.BLL.Services.Abstractions;
using QuizApplication.BLL.ViewModels;
using QuizApplication.DAL.Entity;
using QuizApplication.DAL.Repositories.Abstarctions;

namespace QuizApplication.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _categoryRepository;

        public CategoryService(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository= categoryRepository;    
        }

        public async Task<List<CategoryViewModel>> GetAllCategories()
        {
            List<CategoryViewModel> categoriesViewModels= new List<CategoryViewModel>();
            var categories = await _categoryRepository.GetAllAsync();

            foreach (var category in categories) 
            {
                CategoryViewModel categoryViewModel = new CategoryViewModel()
                {
                    Id=category.Id,
                    Name=category.Name,
                };
                categoriesViewModels.Add(categoryViewModel);
            }
            return categoriesViewModels;
        }
    }
}
