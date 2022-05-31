using WebshopTemplate.ViewModels.Products;
using WebshopTemplate.Models;

namespace WebshopTemplate.Services
{
    public interface IProductService
    {
        public List<Product> GetAllProducts();
        public List<Product> GetProductsByCategory(Category category);
        public Product GetProductById(int id);
        public List<Product> GetProductsByFilter(ProductFilter filter);
        public void CreateProduct(Product product);
        public void UpdateProduct(Product product);
        public void HandleProductImages(Product product);
    }
}
