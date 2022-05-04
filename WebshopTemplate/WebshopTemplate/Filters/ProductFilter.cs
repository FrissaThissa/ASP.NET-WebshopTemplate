using WebshopTemplate.Models;

namespace WebshopTemplate.Filters
{
    public class ProductFilter
    {
        public Category SelectedCategory { get; private set; }
        public string SearchInput { get; private set; }
    }
}
