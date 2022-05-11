using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebshopTemplate.Areas.Identity.Data;
using WebshopTemplate.Models;
using WebshopTemplate.Services;

namespace WebshopTemplate.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;
        private readonly UserManager<WebshopTemplateUser> _userManager;

        public CartController(IProductService productService, ICartService cartService, UserManager<WebshopTemplateUser> userManager)
        {
            _productService = productService;
            _cartService = cartService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            WebshopTemplateUser user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound();
            return View(_cartService.GetUserCart(user));
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(int id, int amount)
        {
            WebshopTemplateUser user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound();
            Cart cart = _cartService.GetUserCart(user);
            _cartService.AddProduct(cart, id, amount);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveProduct(int id)
        {
            WebshopTemplateUser user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound();
            Cart cart = _cartService.GetUserCart(user);
            _cartService.RemoveProduct(cart, id);
            return RedirectToAction("Index");
        }
    }
}
