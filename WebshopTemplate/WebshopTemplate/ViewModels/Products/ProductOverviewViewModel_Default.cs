using WebshopTemplate.Services;
using WebshopTemplate.Models;

namespace WebshopTemplate.ViewModels.Products
{
    public class ProductOverviewViewModel_Default
    {
        private readonly IProductService _productService;

        public ProductFilter Filter { get; private set; }
        public List<Product> Products { get; private set; }

        public ProductOverviewViewModel_Default(IProductService productService, ICategoryService categoryService, ProductFilter filter)
        {
            _productService = productService;
            Filter = filter;
            Products = _productService.GetAllProducts();
            filter.SetBrands(Products);
        }
    }
}