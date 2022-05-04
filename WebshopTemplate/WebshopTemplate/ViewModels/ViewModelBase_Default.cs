using WebshopTemplate.Models;
using WebshopTemplate.Services;

namespace WebshopTemplate.ViewModels
{
    public class ViewModelBase_Default
    {
        private readonly ICategoryService _categoryService;

        public List<Category> Categories { get; private set; }

        public ViewModelBase_Default(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            Categories = _categoryService.GetCategoryTree();
        }
    }
}
