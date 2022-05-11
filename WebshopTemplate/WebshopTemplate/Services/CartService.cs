using WebshopTemplate.Models;
using WebshopTemplate.Areas.Identity.Data;
using WebshopTemplate.Data;
using Microsoft.EntityFrameworkCore;

namespace WebshopTemplate.Services
{
    public class CartService : ICartService
    {
        private readonly WebshopTemplateContext _context;
        private readonly IProductService _productService;

        public CartService(WebshopTemplateContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        public Cart GetUserCart(WebshopTemplateUser user)
        {
            Cart? cart = _context.Carts.Where(c => c.User == user).Include(c => c.Products).ThenInclude(c => c.Product).FirstOrDefault();
            if (cart != null)
                return cart;
            cart = new Cart();
            cart.Products = new List<Cart_Product>();
            cart.User = user;
            _context.Carts.Add(cart);
            _context.SaveChanges();
            return cart;
        }

        public void AddProduct(Cart cart, int productid, int amount)
        {
            Cart_Product product = new Cart_Product();
            product.Product = _productService.GetProductById(productid);
            product.Amount = amount;
            cart.Products.Add(product);
            _context.Cart_Products.Add(product);
            _context.Update(cart);
            _context.SaveChanges();
        }

        public void RemoveProduct(Cart cart, int productid)
        {
            foreach(Cart_Product cart_product in cart.Products)
            {
                if (cart_product.Product.Id != productid)
                    continue;

                cart.Products.Remove(cart_product);
                break;
            }
            _context.Update(cart);
            _context.SaveChanges();
        }
    }
}
