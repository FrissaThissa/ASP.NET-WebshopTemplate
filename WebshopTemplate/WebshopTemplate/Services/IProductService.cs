using WebshopTemplate.Models;

namespace WebshopTemplate.Services
{
    public interface IProductService
    {
        public List<Product> GetAllProducts();
        public List<Product> GetProductsByCategory(Category category);
        public Product GetProductById(int id);
        public void CreateProduct();
    }
}
