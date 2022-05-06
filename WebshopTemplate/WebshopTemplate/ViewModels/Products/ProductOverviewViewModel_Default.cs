using WebshopTemplate.Services;
using WebshopTemplate.Models;

namespace WebshopTemplate.ViewModels
{
    public class ProductOverviewViewModel_Default : ViewModelBase_Default
    {
        private readonly IProductService _productService;

        public List<Product> Products { get; private set; }

        public ProductOverviewViewModel_Default(IProductService productService, ICategoryService categoryService) : base(categoryService)
        {
            _productService = productService;
            Products = _productService.GetAllProducts();
        }
    }
}