using Microsoft.AspNetCore.Mvc;
using WebshopTemplate.Models;
using WebshopTemplate.Services;

namespace WebshopTemplate.Controllers
{
    [ApiController]
    public class ApiController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;

        public ApiController(IProductService productService, ICategoryService categoryService, IBrandService brandService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _brandService = brandService;
        }

        [HttpGet("api/products")]
        public ActionResult<IEnumerable<Product>> Products([FromQuery]int? categoryid)
        {
            if(categoryid == null)
                return _productService.GetAllProducts();
            else
                return _productService.GetProductsByCategory((int)categoryid);
        }

        [HttpGet("api/products/{id}")]
        public ActionResult<Product> Products(int id)
        {
            return _productService.GetProductById(id);
        }

        [HttpGet("api/categories")]
        public ActionResult<IEnumerable<Category>> Categories([FromQuery]int? parentcategoryid)
        {
            if (parentcategoryid == null)
                return _categoryService.GetAllCategories();
            else
                return _categoryService.GetSubCategories((int)parentcategoryid);
        }

        [HttpGet("api/categories/{id}")]
        public ActionResult<Category> Categories(int id)
        {
            return _categoryService.GetCategoryById(id);
        }

        [HttpGet("api/categories/head")]
        public ActionResult<IEnumerable<Category>> HeadCategories()
        {
            return _categoryService.GetHeadCategories();
        }

        [HttpGet("api/brands")]
        public ActionResult<IEnumerable<Brand>> Brands()
        {
            return _brandService.GetAllBrands();
        }

        [HttpGet("api/brands/{id}")]
        public ActionResult<Brand> Brands(int id)
        {
            return _brandService.GetBrandById(id);
        }
    }
}
