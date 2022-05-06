using WebshopTemplate.Filters;
using WebshopTemplate.Models;

namespace WebshopTemplate.Services
{
    public interface IProductService
    {
        public List<Product> GetAllProducts();
        public List<Product> GetProductsByCategory(Category category);
        public Product GetProductById(int id);
        public void CreateProduct();
        public List<Product> GetProductsByFilter(ProductFilter filter);
        public void HandleProductImages(Product product);
    }
}
