using WebshopTemplate.Services;

namespace WebshopTemplate.ViewModels
{
    public class ProductViewModel_Default : ViewModelBase_Default
    {
        private readonly IProductService _productService;

        public ProductViewModel_Default(IProductService productService, ICategoryService categoryService) : base(categoryService)
        {
            _productService = productService;
        }
    }
}