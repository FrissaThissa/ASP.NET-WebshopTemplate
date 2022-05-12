using WebshopTemplate.Models;
using WebshopTemplate.Data;

namespace WebshopTemplate.Services
{
    public class BrandService : IBrandService
    {
        private readonly WebshopTemplateContext _context;

        public BrandService(WebshopTemplateContext context)
        {
            _context = context;
        }

        public Brand GetBrandByName(string name)
        {
            return _context.Brands.Where(b => b.Name == name).FirstOrDefault();
        }

        public List<Brand> GetAllBrands()
        {
            return _context.Brands.ToList();
        }
    }
}
