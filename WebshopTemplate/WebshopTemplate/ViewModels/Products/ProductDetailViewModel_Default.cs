using WebshopTemplate.Models;
using WebshopTemplate.Services;

namespace WebshopTemplate.ViewModels.Products
{
    public class ProductDetailViewModel_Default
    {
        public Product Product { get; private set; }
        public ProductDetailViewModel_Default(ICategoryService categoryService, Product product)
        {
            Product = product;
        }
    }
}
