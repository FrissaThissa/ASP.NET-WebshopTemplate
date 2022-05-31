using WebshopTemplate.Models;

namespace WebshopTemplate.ViewModels.Products
{
    public class ProductFilter
    {
        public string? Category { get; set; }
        public string? Brand { get; set; }
        public string? SearchInput { get; set; }        

        public Dictionary<Brand, int>? Brands { get; set; }

        public void SetBrands(List<Product> products)
        {
            Brands = new Dictionary<Brand, int>();
            foreach (var product in products)
            {
                if (product.Brand == null)
                    continue;
                if (Brands.ContainsKey(product.Brand))
                    Brands[product.Brand]++;
                else
                    Brands.Add(product.Brand, 1);
            }
        }
    }
}
