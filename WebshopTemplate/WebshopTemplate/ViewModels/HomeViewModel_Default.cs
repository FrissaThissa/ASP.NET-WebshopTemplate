using WebshopTemplate.Services;

namespace WebshopTemplate.ViewModels
{
    public class HomeViewModel_Default : ViewModelBase_Default
    {
        public HomeViewModel_Default(ICategoryService categoryService) : base(categoryService)
        {

        }
    }
}
