using WebshopTemplate.Models;
using WebshopTemplate.Services;

namespace WebshopTemplate.ViewModels.Products
{
    public class ProductCreateViewModel
    {
        public Product Product { get; set; }
        public List<Brand> Brands { get; set; }

        public ProductCreateViewModel(IBrandService brandService)
        {
            Product = new Product();
            Brands = brandService.GetAllBrands();
        }
    }
}
