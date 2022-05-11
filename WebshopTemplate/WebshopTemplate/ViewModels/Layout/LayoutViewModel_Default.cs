using WebshopTemplate.Models;
using WebshopTemplate.Services;

namespace WebshopTemplate.ViewModels.Layout
{
    public class LayoutViewModel_Default
    {
        private readonly ICategoryService _categoryService;

        public List<Category> Categories { get; private set; }
        public Wishlist Wishlist { get; private set; }
        public Cart Cart { get; private set; }

        public LayoutViewModel_Default(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            Categories = _categoryService.GetCategoryTree();
        }
    }
}
