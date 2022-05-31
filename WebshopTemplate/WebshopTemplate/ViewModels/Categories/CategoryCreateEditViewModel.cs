using WebshopTemplate.Models;
using WebshopTemplate.Services;

namespace WebshopTemplate.ViewModels.Categories
{
    public class CategoryCreateEditViewModel
    {
        public Category Category { get; set; }
        public List<Category> Categories { get; set; }

        public CategoryCreateEditViewModel(ICategoryService categoryService, Category? category = null)
        {
            if(category == null)
            {
                Category = new Category();
                Categories = categoryService.GetHeadCategories();
            }
            else
            {
                Category = category;
                Categories = categoryService.GetHeadCategories(category);
            }
        }
    }
}
