#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebshopTemplate.Data;
using WebshopTemplate.Models;
using WebshopTemplate.Services;
using WebshopTemplate.Filters;
using WebshopTemplate.ViewModels;
using WebshopTemplate.ViewModels.Products;
using WebshopTemplate.ViewModels.Layout;
using Microsoft.AspNetCore.Identity;
using WebshopTemplate.Areas.Identity.Data;

namespace WebshopTemplate.Controllers
{
    public class ProductsController : Controller
    {
        private readonly WebshopTemplateContext _context;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;
        private readonly UserManager<WebshopTemplateUser> _userManager;

        public ProductsController(WebshopTemplateContext context, IProductService productService, ICategoryService categoryService, IBrandService brandService, UserManager<WebshopTemplateUser> userManager)
        {
            _context = context;
            _productService = productService;
            _categoryService = categoryService;
            _brandService = brandService;
            _userManager = userManager;
        }

        // GET: Products
        public async Task<IActionResult> Index([FromQuery] ProductFilter filter)
        {
            ProductOverviewViewModel_Default model = new ProductOverviewViewModel_Default(_productService, _categoryService, filter);
            return View("Index_Customer", model);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Product product = _productService.GetProductById(id);
            if (product == null)
                return NotFound();

            ProductDetailViewModel_Default model = new ProductDetailViewModel_Default(_categoryService, product);

            return View("Details_Customer", model);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ProductCreateEditViewModel model = new ProductCreateEditViewModel(_brandService, _categoryService);
            return View(model);
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.CreateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            ProductCreateEditViewModel model = new ProductCreateEditViewModel(_brandService, _categoryService);
            model.Product = product;
            return View(model);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            ProductCreateEditViewModel model = new ProductCreateEditViewModel(_brandService, _categoryService);
            model.Product = _productService.GetProductById(id);
            return View(model);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ProductCreateEditViewModel model = new ProductCreateEditViewModel(_brandService, _categoryService);
            model.Product = product;
            return View(model);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
