using WebshopTemplate.Areas.Identity.Data;
using WebshopTemplate.Models;

namespace WebshopTemplate.Services
{
    public interface IWishlistService
    {
        public Wishlist GetUserWishlist(WebshopTemplateUser user);
        public void AddProduct(Wishlist wishlist, int productid);
        public void RemoveProduct(Wishlist wishlist, int productid);
    }
}
