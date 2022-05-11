using WebshopTemplate.Models;
using WebshopTemplate.Areas.Identity.Data;

namespace WebshopTemplate.Services
{
    public interface ICartService
    {
        public Cart GetUserCart(WebshopTemplateUser user);
        public void AddProduct(Cart cart, int productid, int amount);
        public void RemoveProduct(Cart cart, int productid);
    }
}
