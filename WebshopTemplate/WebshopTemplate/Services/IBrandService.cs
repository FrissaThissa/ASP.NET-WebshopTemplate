using WebshopTemplate.Models;

namespace WebshopTemplate.Services
{
    public interface IBrandService
    {
        public Brand GetBrandByName(string name);
        public List<Brand> GetAllBrands();
    }
}
