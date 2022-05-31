using WebshopTemplate.Models;
using WebshopTemplate.Services;

namespace WebshopTemplate.ViewModels.Products
{
    public class ProductCreateEditViewModel
    {
        public Product Product { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Category> Categories { get; set; }

        public ProductCreateEditViewModel(IBrandService brandService, ICategoryService categoryService)
        {
            Product = new Product();
            Brands = brandService.GetAllBrands();
            Categories = categoryService.GetAllCategories();
        }
    }
}