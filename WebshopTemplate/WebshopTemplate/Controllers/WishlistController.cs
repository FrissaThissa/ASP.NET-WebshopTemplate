using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebshopTemplate.Areas.Identity.Data;
using WebshopTemplate.Models;
using WebshopTemplate.Services;

namespace WebshopTemplate.Controllers
{
    public class WishlistController : Controller
    {
        private readonly IProductService _productService;
        private readonly IWishlistService _wishlistService;
        private readonly UserManager<WebshopTemplateUser> _userManager;

        public WishlistController(IProductService productService, IWishlistService wishlistService, UserManager<WebshopTemplateUser> userManager)
        {
            _productService = productService;
            _wishlistService = wishlistService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            WebshopTemplateUser user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound();
            return View(_wishlistService.GetUserWishlist(user));
        }

        public async Task<IActionResult> AddProduct(int id)
        {
            WebshopTemplateUser user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound();
            Wishlist wishlist = _wishlistService.GetUserWishlist(user);
            _wishlistService.AddProduct(wishlist, id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveProduct(int id)
        {
            WebshopTemplateUser user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound();
            Wishlist wishlist = _wishlistService.GetUserWishlist(user);
            _wishlistService.RemoveProduct(wishlist, id);
            return RedirectToAction("Index");
        }
    }
}
