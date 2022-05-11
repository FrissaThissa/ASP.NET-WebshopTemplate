using Microsoft.EntityFrameworkCore;
using WebshopTemplate.Areas.Identity.Data;
using WebshopTemplate.Data;
using WebshopTemplate.Models;

namespace WebshopTemplate.Services
{
    public class WishlistService : IWishlistService
    {
        private readonly WebshopTemplateContext _context;
        private readonly IProductService _productService;

        public WishlistService(WebshopTemplateContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }        

        public Wishlist GetUserWishlist(WebshopTemplateUser user)
        {
            Wishlist? wishlist = _context.Wishlists.Where(c => c.User == user).Include(c => c.Products).FirstOrDefault();
            if (wishlist != null)
                return wishlist;
            wishlist = new Wishlist();
            wishlist.Products = new List<Product>();
            wishlist.User = user;
            _context.Wishlists.Add(wishlist);
            _context.SaveChanges();
            return wishlist;
        }

        public void AddProduct(Wishlist wishlist, int productid)
        {
            wishlist.Products.Add(_productService.GetProductById(productid));
            _context.Update(wishlist);
            _context.SaveChanges();
        }

        public void RemoveProduct(Wishlist wishlist, int productid)
        {
            wishlist.Products.Remove(_productService.GetProductById(productid));
            _context.Update(wishlist);
            _context.SaveChanges();
        }
    }
}
