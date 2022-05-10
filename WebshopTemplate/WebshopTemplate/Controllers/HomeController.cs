using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebshopTemplate.Models;
using WebshopTemplate.ViewModels;
using WebshopTemplate.Services;
using WebshopTemplate.ViewModels.Layout;

namespace WebshopTemplate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View(new HomeViewModel_Default(_categoryService));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}