using WebshopTemplate.Models;
using WebshopTemplate.Data;

namespace WebshopTemplate.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly WebshopTemplateContext _context;

        public CategoryService(WebshopTemplateContext context)
        {
            _context = context;
        }

        public void CreateCategory()
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public List<Category> GetCategoryTree()
        {
            return _context.Categories.ToList();
        }

        public List<Category> GetHeadCategories()
        {
            throw new NotImplementedException();
        }

        public List<Category> GetSubCategories(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
