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

        public void CreateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(Category category)
        {

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
            return _context.Categories.Where(c => c.ParentCategory == null).ToList();
        }

        public List<Category> GetHeadCategories(Category category)
        {
            return _context.Categories.Where(c => c.ParentCategory == null).Where(c => c.Id != category.Id).ToList();
        }

        public List<Category> GetSubCategories(Category category)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetSubCategories(int parentCategoryId)
        {
            return _context.Categories.Where(c => c.ParentCategoryId == parentCategoryId).ToList();
        }

        public Category GetCategoryByName(string name)
        {
            return _context.Categories.Where(c => c.Name == name).FirstOrDefault();
        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories.Where(c => c.Id == id).FirstOrDefault();
        }
    }
}
