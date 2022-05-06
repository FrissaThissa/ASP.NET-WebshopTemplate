using WebshopTemplate.Models;
using WebshopTemplate.Filters;
using WebshopTemplate.Data;

namespace WebshopTemplate.Services
{
    public class ProductService : IProductService
    {
        private readonly WebshopTemplateContext _context;

        public ProductService(WebshopTemplateContext context)
        {
            _context = context;
        }

        public void CreateProduct()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByFilter(ProductFilter filter)
        {
            return _context.Products.ToList();
        }
    }
}
